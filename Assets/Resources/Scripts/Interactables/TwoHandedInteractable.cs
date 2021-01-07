using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoHandedInteractable : MonoBehaviour
{
    public GameObject tempShit;
    public GameObject tempShit2;
    private HandPhysics dominantHand;
    private HandPhysics secondaryHand;
    private int originalPhysicsLayer;
    private bool interactionActive;
    private Rigidbody rb;
    public Vector3 rotationOffset;
    private Quaternion rotationOffsetQ;

    private Vector3 dominantGripPosition;

    void Start() {
        rb = GetComponent<Rigidbody>();
        rotationOffsetQ = Quaternion.Euler(rotationOffset.x, rotationOffset.y, rotationOffset.z);
        addHand(tempShit);
        addHand(tempShit2);
    }

    private void swapDominant() {
        if (dominantHand.getGrip() < secondaryHand.getGrip()) {
            HandPhysics swap = dominantHand;
            dominantHand = secondaryHand;
            secondaryHand = swap;
        }
    }

    void FixedUpdate() {
        if (interactionActive) {
            Vector3 position;
            Quaternion rotation;
            if (secondaryHand == null) {
                position = dominantHand.getPosition(dominantGripPosition);
                rotation = dominantHand.getRotation();
            } else {
                swapDominant();
                position = dominantHand.getPosition();
                rotation = Quaternion.LookRotation(position - secondaryHand.getPosition());
                Vector3 direction = (position - secondaryHand.getPosition()).normalized;
                position += direction * (-0.3f);
            }
            rb.MoveRotation(rotation * rotationOffsetQ);
            rb.MovePosition(position);
        }
    }

    private void startInteraction(GameObject hand) {
        originalPhysicsLayer = this.gameObject.layer;
        interactionActive = true;
        dominantHand = hand.GetComponent<HandPhysics>();
        rb.useGravity = false;
        this.gameObject.layer = hand.layer;
        dominantGripPosition = new Vector3(0,-0.3f,0);
    }

    public void addHand(GameObject hand) {
        if (interactionActive) {
            secondaryHand = hand.GetComponent<HandPhysics>();
        } else {
            startInteraction(hand);
        }
    }
}
