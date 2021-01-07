using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandPhysics : MonoBehaviour
{
    public GameObject handTarget;
    private XRHand handController;
    private Rigidbody rb;
    private float gripStrength;
    void Start() {
        rb = GetComponent<Rigidbody>();
        handController = handTarget.GetComponent<XRHand>();
    }

    void FixedUpdate() {
        rb.MovePosition(handTarget.transform.position);
        rb.MoveRotation(handTarget.transform.rotation);
        gripStrength = handController.getGrip();
    }

    public Vector3 getPosition() {
        return getPosition(new Vector3(0,0,0));
    }

    public Vector3 getPosition(Vector3 offset) {
        Vector3 position = handTarget.transform.TransformPoint(offset);
        return position;
    }

    public Quaternion getRotation() {
        return handTarget.transform.rotation;
    }

    public float getGrip() {
        return gripStrength;
    }
}
