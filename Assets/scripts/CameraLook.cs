using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour
{
    public float zoom = 20.0f;
    public Transform target;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = target.position + new Vector3(-zoom, zoom * 1.25f, -zoom);
        transform.LookAt(target);
    }
}
