using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandPhysics : MonoBehaviour
{
    public GameObject handTarget;
    private XRHand handController;
    private Rigidbody rb;
    private float gripStrength;
    private bool right;
    void Start() {
        rb = GetComponent<Rigidbody>();
        handController = handTarget.GetComponent<XRHand>();
        right = handController.isRight();
    }

    void FixedUpdate() {
        rb.MovePosition(handTarget.transform.position);
        rb.MoveRotation(handTarget.transform.rotation);
        gripStrength = handController.getGrip();
    }

    public Vector3 getPosition() {
        return handTarget.transform.position;
    }

    public Quaternion getRotation() {
        return handTarget.transform.rotation;
    }

    public float getGrip() {
        return gripStrength;
    }

    public bool isRight() {
        return right;
    }
}
