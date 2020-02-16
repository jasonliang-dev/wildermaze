using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHunger : MonoBehaviour
{
    public float hunger = 1.0f;
    public Slider bar;
    public Transform endTrigger;

    private PlayerHealth healthScript;
    private WinTrigger winTrigger;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SlowDecreaseHunger", 5.0f, 0.4f);
        bar.value = hunger;
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
    }

    private void SlowDecreaseHunger()
    {
        hunger -= 0.01f;
        bar.value = hunger;

        if (hunger <= 0.0f)
        {
            healthScript.Health = 0;
        }
    }

    public void IncreaseHunger()
    {
        hunger += 0.1f;
        bar.value = hunger;
    }
}
