using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float mainThrust = 100f;
    [SerializeField] float rotationThrust = 1f;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    private void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            ApplyRotation(-rotationThrust);

        }
        else if (Input.GetKey(KeyCode.D))
        {
            ApplyRotation(rotationThrust);
        }
    }

    private void ApplyRotation(float rotationThisFrame) 
    {
        rb.freezeRotation = true;  // freezing rotation so we can manually rotate
        transform.Rotate(-Vector3.forward * rotationThisFrame  * Time.deltaTime);
        rb.freezeRotation = false; // unfreeze rotation so physics engine can take over
    }

    private void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime, ForceMode.Force);
        }
    }
}
