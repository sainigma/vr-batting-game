using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Rigidbody rb;
    Vector3 initialVelocity = Vector3.zero;
    void Start() {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate() {
        if (initialVelocity != Vector3.zero) {
            rb.velocity = initialVelocity;
            initialVelocity = Vector3.zero;
        }
    }

    public void setVelocity(Vector3 velocity) {
        initialVelocity = velocity;
    }
}
