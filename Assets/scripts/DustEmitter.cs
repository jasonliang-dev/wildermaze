using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustEmitter : MonoBehaviour
{
    public Transform dustPool;
    public bool stopped = true;
    public Transform dustSpawner;
    public AudioSource audioSource;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Invoke("CreateDust", 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void CreateDust()
    {
        Invoke("CreateDust", Random.Range(0.2f, 0.8f));

        if (stopped)
        {
            return;
        }

        foreach (Transform dust in dustPool)
        {
            if (!dust.gameObject.activeSelf)
            {
                dust.gameObject.SetActive(true);
                dust.position = dustSpawner.position;
                dust.LookAt(Vector3.up);
                dust.transform.localScale = Vector3.one;

                if (audioSource != null) audioSource.Play();
                break;
            }
        }
    }
}
