using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float speed;
    private int _counter = 0;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.forward * speed;
    }

    private void Update()
    {
        if (_counter == 3)
        {
            Destroy(gameObject);
        }
        
    }

    private void OnCollisionEnter(Collision other)
    {
        _counter++;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Water")) Destroy(gameObject);
    }
}
