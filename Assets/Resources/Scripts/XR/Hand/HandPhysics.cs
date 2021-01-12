using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandPhysics : MonoBehaviour
{
    public GameObject handTarget;
    public XRHand handController;
    private Rigidbody rb;
    private Collider grabSphere;
    private Collision currentCollision;
    private XRUtils xrUtils;
    private int originalLayer;
    private float gripStrength;
    private bool right;
    private bool grabbing;
    public bool ready = false;

    void Start() {
        originalLayer = gameObject.layer;
        grabSphere = GetComponent<SphereCollider>();
        rb = GetComponent<Rigidbody>();
        xrUtils = new XRUtils();
    }

    void FixedUpdate() {
        if (!ready) {
            return;
        }
        xrUtils.TransformRigidbody(rb, handTarget.transform.position, handTarget.transform.rotation);
        checkCollision();
    }

    public void setHandTarget(GameObject handTarget, bool isRight) {
        this.handTarget = handTarget;
        handController = handTarget.GetComponent<XRHand>();
        right = isRight;
        ready = true;
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
                currentCollision.gameObject.GetComponent<TwoHandedInteractable>().addHand(this.gameObject, currentCollision.GetContact(0).point, originalLayer);
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
