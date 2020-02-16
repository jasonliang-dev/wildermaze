using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarrotCollision : MonoBehaviour
{
    public GameObject player;
    public Transform explode;

    private PlayerHunger hungerScript;
    private PlayerHealth healthScript;

    // Start is called before the first frame update
    void Start()
    {
        hungerScript = player.GetComponent<PlayerHunger>();
        healthScript = player.GetComponent<PlayerHealth>();
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

        healthScript.Health += 1;
        hungerScript.IncreaseHunger();

        explode.position = transform.position;
        foreach (Transform box in explode)
        {
            box.gameObject.SetActive(true);
            box.SetPositionAndRotation(explode.position, Random.rotation);
            box.GetComponent<Rigidbody>().AddForce(box.forward * 1000.0f);
            box.transform.localScale = Vector3.one;
        }

        Destroy(gameObject);
    }
}
