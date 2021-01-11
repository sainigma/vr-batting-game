﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoHandedInteractable : MonoBehaviour
{
    private HandPhysics dominantHand;
    private HandPhysics secondaryHand;
    private bool interactionActive;
    private Rigidbody rb;
    public Vector3 rotationOffset;
    private Quaternion rotationOffsetQ;
    private XRUtils xrUtils;
    private float fulcrumOffset;

    void Start() {
        xrUtils = new XRUtils();
        rb = GetComponent<Rigidbody>();
        rb.maxAngularVelocity = 20f;
        rotationOffsetQ = Quaternion.Euler(rotationOffset.x, rotationOffset.y, rotationOffset.z);
    }

    private void swapDominant() {
        swapDominant(false);
    }

    private void swapDominant(bool force) {
        if (force || dominantHand.getGrip() < secondaryHand.getGrip()) {
            Vector3 dominantPosition = dominantHand.getPosition();
            Vector3 secondaryPosition = secondaryHand.getPosition();

            fulcrumOffset = (dominantPosition - secondaryPosition).magnitude - fulcrumOffset;

            HandPhysics swap = dominantHand;
            dominantHand = secondaryHand;
            secondaryHand = swap;
        }
    }

    private bool checkHand(HandPhysics hand) {
        bool popped = false;
        if (hand != null) {
            if (hand.getGrip() < 0.1f) {
                popHand();
                popped = true;
            }
        } else {
            return false;
        }
        if (popped && dominantHand != null) {
            fulcrumOffset = (this.transform.position - dominantHand.getPosition()).magnitude;
        }
        return !popped;
    }

    private bool checkHands() {
        bool a, b;
        a = checkHand(secondaryHand);
        b = checkHand(dominantHand);
        return a || b;
    }

    void FixedUpdate() {
        if (interactionActive) {
            if (!checkHands()) {
                return;
            }

            Vector3 position;
            Quaternion rotation;

            if (secondaryHand == null) {
                position = dominantHand.getPosition();
                rotation = rb.rotation;
            } else {
                swapDominant();
                Vector3 helper = dominantHand.transform.right;
                position = dominantHand.getPosition();
                Vector3 secondaryPosition = secondaryHand.getPosition();
                if ((position - rb.position).magnitude < (secondaryPosition - rb.position).magnitude) {
                    rotation = Quaternion.LookRotation(secondaryPosition - position, helper);
                } else {
                    rotation = Quaternion.LookRotation(position - secondaryPosition, helper);
                }
            }

            Vector3 offset = new Vector3(0, 0, -fulcrumOffset);
            offset = rotation * offset;
            position += offset;

            xrUtils.TransformRigidbody(rb, position, rotation);
        }
    }

    private void startInteraction(GameObject hand) {
        rb.isKinematic = false;
        interactionActive = true;
        dominantHand = hand.GetComponent<HandPhysics>();
        rb.useGravity = false;
    }
    
    private void endInteraction() {
        interactionActive = false;
        rb.useGravity = true;
        rb.isKinematic = false;
    }

    public void addHand(GameObject hand, Vector3 position) {
        if (interactionActive) {
            secondaryHand = hand.GetComponent<HandPhysics>();
            swapDominant(true);
        } else {
            fulcrumOffset = (this.transform.position - position).magnitude;
            startInteraction(hand);
        }
    }

    public void popHand() {
        if (secondaryHand != null) {
            secondaryHand = null;
        } else {
            dominantHand = null;
            endInteraction();
        }
    }
}
