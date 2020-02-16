using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarrotCube : MonoBehaviour
{
    private float shrinkRate;

    // Start is called before the first frame update
    void Start()
    {
        shrinkRate = Random.Range(0.96f, 0.98f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale *= shrinkRate;

        if (transform.localScale.magnitude < 0.05f)
        {
            gameObject.SetActive(false);
        }
    }
}
