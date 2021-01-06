using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandPhysics : MonoBehaviour
{
    public GameObject handTarget;
    private Rigidbody rb;
    void Start() {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate() {
        rb.MovePosition(handTarget.transform.position);
    }
}
