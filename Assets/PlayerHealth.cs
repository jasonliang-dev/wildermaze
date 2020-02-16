using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public enum PlayerState
    {
        Alive,
        Stunned,
        Dead
    }

    public Slider bar;
    public Text winText;
    public GameObject restart;

    private RestartScene restartScript;
    private PlayerState _state = PlayerState.Alive;
    public PlayerState State
    {
        get
        {
            return _state;
        }
    }

    private bool isRed = false;
    private Color normalColor;
    private MeshRenderer childRenderer;
    private int _health;
    public int Health
    {
        get
        {
            return _health;
        }
        set
        {
            if (_state != PlayerState.Alive)
            {
                return;
            }

            if (_health > value)
            {
                _state = PlayerState.Stunned;
                InvokeRepeating("Flash", 0.0f, 0.2f);
                Invoke("UnStun", 3.0f);
            }

            _health = Mathf.Clamp(value, 0, 3);
            bar.value = value / 3.0f;

            if (_health == 0)
            {
                CancelInvoke("UnStun");
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90));
                _state = PlayerState.Dead;
                winText.text = "Game Over!";
                restartScript.ShowButton();
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        _health = 3;
        bar.value = _health;
        childRenderer = gameObject.GetComponentInChildren<MeshRenderer>();
        restartScript = restart.GetComponent<RestartScene>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void UnStun()
    {
        _state = PlayerState.Alive;
        CancelInvoke("Flash");
        childRenderer.material.color = normalColor;
    }

    private void Flash()
    {
        if (normalColor == null)
        {
            normalColor = childRenderer.material.color;
        }

        childRenderer.material.color = isRed ? normalColor : Color.red;
        isRed = !isRed;
    }
}
