using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 3.0f;
    public float rotateSpeed = 1.0f;
    private Vector3 velocity;
    private Rigidbody rb;
    private PlayerHealth healthScript;
    private DustEmitter dustEmitter;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        healthScript = GetComponent<PlayerHealth>();
        dustEmitter = GetComponent<DustEmitter>();
    }

    // Update is called once per frame
    void Update()
    {
        if (healthScript.State == PlayerHealth.PlayerState.Dead)
        {
            dustEmitter.stopped = true;
            return;
        }

        float vx = Input.GetAxisRaw("Vertical");
        float vz = -Input.GetAxisRaw("Horizontal");
        velocity = Quaternion.Euler(0, -45, 0) * new Vector3(vx, 0, vz);

        Vector3 nextDir = Vector3.RotateTowards(transform.forward, velocity, rotateSpeed * Time.deltaTime, 0.0f);
        transform.rotation = Quaternion.LookRotation(nextDir);
        dustEmitter.stopped = velocity.magnitude <= 0;
    }

    void FixedUpdate()
    {
        Vector3 delta = velocity * speed * Time.fixedDeltaTime;
        rb.MovePosition(transform.position + delta);
    }
}
