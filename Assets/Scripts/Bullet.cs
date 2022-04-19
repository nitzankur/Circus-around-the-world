using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float speed;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.forward * speed;
    }
    
    private void OnCollisionExit(Collision other)
    {
        Destroy(gameObject);
    }
}
