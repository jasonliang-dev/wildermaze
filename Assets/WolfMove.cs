using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WolfMove : MonoBehaviour
{
    public float recalculateTime = 2.0f;
    public NavMeshAgent agent;
    public GameObject player;
    public Transform endTrigger;

    private PlayerHunger hungerScript;
    private PlayerHealth healthScript;
    private WinTrigger winTrigger;
    private DustEmitter dustEmitter;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("ResetDestination", 0.0f, recalculateTime);
        hungerScript = player.GetComponent<PlayerHunger>();
        healthScript = player.GetComponent<PlayerHealth>();
        winTrigger = endTrigger.GetComponent<WinTrigger>();
        dustEmitter = GetComponent<DustEmitter>();
        dustEmitter.stopped = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (healthScript.State == PlayerHealth.PlayerState.Dead || winTrigger.Triggered)
        {
            agent.isStopped = true;
            agent.velocity = Vector3.zero;
            dustEmitter.stopped = true;
            CancelInvoke("ResetDestination");
        }
    }

    private void ResetDestination()
    {
        agent.SetDestination(player.transform.position);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            healthScript.Health -= 1;
        }
    }
}
