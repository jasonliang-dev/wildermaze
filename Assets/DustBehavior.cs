using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustBehavior : MonoBehaviour
{
    private float speed;
    private float shrinkRate;

    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(4.0f, 6.0f);
        shrinkRate = Random.Range(0.95f, 0.97f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.forward * speed * Time.deltaTime);
        transform.localScale *= shrinkRate;

        if (transform.localScale.magnitude < 0.05f)
        {
            gameObject.SetActive(false);
        }
    }
}
