using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinTrigger : MonoBehaviour
{
    public Text winText;
    public GameObject restart;
    public AudioSource jingle;

    private RestartScene restartScript;
    private bool _triggered = false;
    public bool Triggered
    {
        get
        {
            return _triggered;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        winText.text = "";
        restartScript = restart.GetComponent<RestartScene>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) {
            return;
        }

        winText.text = "You Win!";
        _triggered = true;
        restartScript.ShowButton();
        jingle.Play();
    }
}
