using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingSystem : MonoBehaviour
{
    [SerializeField] private GameObject Shot;
    [SerializeField] private GameObject Seat;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject shot = Instantiate(Shot, transform);
            shot.transform.eulerAngles = Seat.transform.eulerAngles;
            shot.GetComponent<Rigidbody>().velocity += Vector3.right * 3;
        }
    }
}
