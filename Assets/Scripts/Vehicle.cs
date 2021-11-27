using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : MonoBehaviour
{
    [SerializeField] public float speed;

    private Rigidbody Rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Rigidbody.AddForce(transform.forward * speed/2, ForceMode.VelocityChange);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<TrafficController>().GameOver();
        }

        if (other.gameObject.CompareTag("EndWall"))
        {
            Destroy(this.gameObject);
        }
    }
}
