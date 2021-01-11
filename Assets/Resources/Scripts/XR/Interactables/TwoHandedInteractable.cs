using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoHandedInteractable : MonoBehaviour
{
    private HandPhysics dominantHand;
    private HandPhysics secondaryHand;
    private int originalPhysicsLayer;
    private bool interactionActive;
    private Rigidbody rb;
    public Vector3 rotationOffset;
    private Quaternion rotationOffsetQ;
    private XRUtils xrUtils;
    private float fulcrumOffset;
    private bool right = true;

    void Start() {
        xrUtils = new XRUtils();
        rb = GetComponent<Rigidbody>();
        rb.maxAngularVelocity = 20f;
        rotationOffsetQ = Quaternion.Euler(rotationOffset.x, rotationOffset.y, rotationOffset.z);
    }

    private void swapDominant() {
        if (dominantHand.getGrip() < secondaryHand.getGrip()) {
            Vector3 dominantPosition = dominantHand.getPosition();
            Vector3 secondaryPosition = secondaryHand.getPosition();

            fulcrumOffset = (dominantPosition - secondaryPosition).magnitude - fulcrumOffset;

            HandPhysics swap = dominantHand;
            dominantHand = secondaryHand;
            secondaryHand = swap;

            right = !right;
        }
    }

    private void checkSecondaryPosition() {
        float a = (dominantHand.getPosition() - secondaryHand.getPosition()).magnitude;
        float b = Mathf.Abs(fulcrumOffset);
        if (a > b && right) {
            Debug.Log(a+" ja "+b);
            popHand();
        }
    }

    void FixedUpdate() {
        if (interactionActive) {
            Vector3 position;
            Quaternion rotation;
            Vector3 direction;
            Vector3 helper = dominantHand.transform.right;

            if (secondaryHand == null) {
                position = dominantHand.getPosition();
                direction = dominantHand.transform.up;
                rotation = Quaternion.LookRotation(direction, helper);
                if (dominantHand.getGrip() < 0.1f) {
                    popHand();
                }
                //rotation = rotation * rotationOffsetQ;
            } else {
                swapDominant();
                position = dominantHand.getPosition();
                Vector3 secondaryPosition = secondaryHand.getPosition();
                rotation = position - secondaryPosition != Vector3.zero 
                    ? right
                        ? Quaternion.LookRotation(position - secondaryPosition, helper)
                        : Quaternion.LookRotation(secondaryPosition - position, helper)
                    : dominantHand.getRotation();
                direction = (position - secondaryHand.getPosition()).normalized;
                if (secondaryHand != null) {
                    checkSecondaryPosition();
                }
            }
            position += direction * (-fulcrumOffset);
            xrUtils.TransformRigidbody(rb, position, rotation);
        }
    }

    private void startInteraction(GameObject hand) {
        //rb.isKinematic = true;
        originalPhysicsLayer = hand.gameObject.layer;
        xrUtils.setPhysicsLayer(this.gameObject.layer, hand);
        interactionActive = true;
        dominantHand = hand.GetComponent<HandPhysics>();
        rb.useGravity = false;
        right = true;
        //right = dominantHand.isRight();
    }
    
    private void endInteraction() {
        //this.gameObject.layer = originalPhysicsLayer;
        interactionActive = false;
        rb.useGravity = true;
        rb.isKinematic = false;
    }

    public void addHand(GameObject hand, Vector3 position) {
        if (interactionActive) {
            secondaryHand = hand.GetComponent<HandPhysics>();
        } else {
            fulcrumOffset = (this.transform.position - position).magnitude;
            startInteraction(hand);
        }
    }

    public void popHand() {
        if (secondaryHand != null) {
            xrUtils.setPhysicsLayer(originalPhysicsLayer, secondaryHand.gameObject);
            secondaryHand = null;
        } else {
            xrUtils.setPhysicsLayer(originalPhysicsLayer, dominantHand.gameObject);
            dominantHand = null;
            endInteraction();
        }
    }
}
