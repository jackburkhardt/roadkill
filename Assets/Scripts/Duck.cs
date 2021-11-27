using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Duck : MonoBehaviour
{
    private float speed = 30;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void FixedUpdate()
    {
        transform.RotateAround(transform.position, Vector3.up, speed * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<AudioHandler>().Play("quack");
            FindObjectOfType<TrafficController>().DuckFound();
            Destroy(this.gameObject);
        }
    }
}
