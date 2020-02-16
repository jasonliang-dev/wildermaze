using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHunger : MonoBehaviour
{
    public float hunger = 1.0f;
    public Transform endTrigger;
    public Image img;

    private PlayerHealth healthScript;
    private WinTrigger winTrigger;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SlowDecreaseHunger", 5.0f, 0.4f);
        img.fillAmount = hunger;
        healthScript = GetComponent<PlayerHealth>();
        winTrigger = endTrigger.GetComponent<WinTrigger>();
    }

    // Update is called once per frame
    void Update()
    {
        if (healthScript.State == PlayerHealth.PlayerState.Dead || winTrigger.Triggered)
        {
            CancelInvoke("SlowDecreaseHunger");
        }

        Vector2 viewPos = Camera.main.WorldToViewportPoint(transform.position);
        Vector2 anchor = viewPos + new Vector2(0.075f, 0.025f);
        img.rectTransform.anchorMin = anchor;
        img.rectTransform.anchorMax = anchor;
    }

    private void SlowDecreaseHunger()
    {
        hunger = Mathf.Clamp(hunger - 0.01f, 0, 1);
        img.fillAmount = hunger;

        if (hunger <= 0.0f)
        {
            healthScript.Health = 0;
        }
    }

    public void IncreaseHunger()
    {
        hunger = Mathf.Clamp(hunger + 0.2f, 0, 1);
        img.fillAmount = hunger;
    }
}
