using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOrbit : MonoBehaviour
{
    public Transform target;
    public float panSpeed = 3.0f;

    private Vector3 center;
    private float angle = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        center = target.position + new Vector3(0, 8, 0);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 delta = Quaternion.Euler(0, angle, 0) * (-Vector3.forward * 24.0f);
        transform.position = center + delta;
        transform.LookAt(target);
        angle -= Time.deltaTime * panSpeed;
    }
}
