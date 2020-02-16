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

    public int maxHealth = 3;
    public Canvas canvas;
    public Image filledHeart;
    public Image emptyHeart;
    public Text winText;
    public GameObject restart;
    public AudioSource jingle;

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
                Invoke("UnStun", 2.0f);
            }

            _health = Mathf.Clamp(value, 0, maxHealth);

            if (_health == 0)
            {
                CancelInvoke("UnStun");
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90));
                _state = PlayerState.Dead;
                winText.text = "Game Over!";
                restartScript.ShowButton();
                jingle.Play();
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        _health = maxHealth;
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

    void OnGUI()
    {
        int pos = 0;

        for (int i = 0; i < _health; i++, pos += 64)
        {
            GUI.DrawTexture(new Rect(pos, 0, 64, 64), filledHeart.sprite.texture);
        }

        for (int i = 0; i < maxHealth - _health; i++, pos += 64)
        {
            GUI.DrawTexture(new Rect(pos, 0, 64, 64), emptyHeart.sprite.texture);
        }
    }
}
