using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandPhysics : MonoBehaviour
{
    public GameObject handTarget;
    private XRHand handController;
    private Rigidbody rb;
    private Collider grabSphere;
    private Collision currentCollision;
    private XRUtils xrUtils;
    private int originalLayer;
    private float gripStrength;
    private bool right;
    private bool grabbing;

    void Start() {
        originalLayer = gameObject.layer;
        grabSphere = GetComponent<SphereCollider>();
        rb = GetComponent<Rigidbody>();
        xrUtils = new XRUtils();
        handController = handTarget.GetComponent<XRHand>();
        right = handController.isRight();
    }

    void FixedUpdate() {
        xrUtils.TransformRigidbody(rb, handTarget.transform.position, handTarget.transform.rotation);
        checkCollision();
    }

    private void checkGrabFinished() {
        if (grabbing && getGrip() < 0.1f) {
            grabbing = false;
            xrUtils.setPhysicsLayer(originalLayer, gameObject);
        }
    }

    private void checkCollision() {
        if (currentCollision == null) {
            checkGrabFinished();
            return;
        } else if (!grabbing) {
            if (currentCollision.gameObject.tag == "Interactable" && getGrip() > 0.1f) {
                xrUtils.setPhysicsLayer(currentCollision.gameObject.layer, gameObject);
                currentCollision.gameObject.GetComponent<TwoHandedInteractable>().addHand(this.gameObject, currentCollision.GetContact(0).point);
                grabbing = true;
            }
        }
    }

    private void OnCollisionEnter(Collision collision) {
        currentCollision = collision;
    }

    private void OnCollisionExit(Collision other) {
        currentCollision = null;
    }

    public Vector3 getPosition() {
        return transform.position;
        //return handTarget.transform.position;
    }

    public Quaternion getRotation() {
        return transform.rotation;
        //return handTarget.transform.rotation;
    }

    public float getGrip() {
        return handController.getGrip();
    }

    public bool isRight() {
        return right;
    }
}
