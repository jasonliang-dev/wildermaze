using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustEmitter : MonoBehaviour
{
    public Transform dustPool;
    public float threshold = 5.0f;
    public bool stopped = true;

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
        Invoke("CreateDust", Random.Range(0.3f, 0.7f));

        if (stopped)
        {
            return;
        }

        foreach (Transform dust in dustPool)
        {
            if (!dust.gameObject.activeSelf)
            {
                dust.gameObject.SetActive(true);
                dust.position = transform.position + new Vector3(0, -1, 0);
                dust.LookAt(Vector3.up);
                dust.transform.localScale = Vector3.one;
                break;
            }
        }
    }
}
