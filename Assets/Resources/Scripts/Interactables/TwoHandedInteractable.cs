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
    private float fulcrumOffset;
    private bool right = true;

    void Start() {
        rb = GetComponent<Rigidbody>();
        rb.maxAngularVelocity = 20f;
        rotationOffsetQ = Quaternion.Euler(rotationOffset.x, rotationOffset.y, rotationOffset.z);
        addHand(tempShit);
        addHand(tempShit2);
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
        if ((dominantHand.getPosition() - secondaryHand.getPosition()).magnitude > Mathf.Abs(fulcrumOffset)) {
            //popHand();
        }
    }

    void FixedUpdate() {
        if (interactionActive) {
            Vector3 position;
            Quaternion rotation;
            Vector3 direction;
            if (secondaryHand != null) {
                checkSecondaryPosition();
            }
            if (secondaryHand == null) {
                position = dominantHand.getPosition();
                direction = dominantHand.transform.up;
                rotation = Quaternion.LookRotation(direction, dominantHand.transform.right);
            } else {
                swapDominant();
                Vector3 helper = dominantHand.transform.right;
                position = dominantHand.getPosition();
                Vector3 secondaryPosition = secondaryHand.getPosition();
                rotation = position - secondaryPosition != Vector3.zero 
                    ? right
                        ? Quaternion.LookRotation(position - secondaryPosition, helper)
                        : Quaternion.LookRotation(secondaryPosition - position, helper)
                    : dominantHand.getRotation();
                direction = (position - secondaryHand.getPosition()).normalized;
            }
            position += direction * (-fulcrumOffset);
            rotation = rotation * rotationOffsetQ;
            if (rb.isKinematic) {
                rb.MoveRotation(rotation);
                rb.MovePosition(position);
            } else {
                Vector3 velocity = (position - rb.position) / Time.deltaTime;
                rb.velocity = velocity;
                Quaternion deltaRotation = rotation * Quaternion.Inverse(rb.rotation);
                float rotAngle;
                Vector3 rotAxis;
                deltaRotation.ToAngleAxis(out rotAngle, out rotAxis);
                if (!float.IsInfinity(rotAngle) && Mathf.Abs(rotAngle) > 0.01f) {
                    if (rotAngle > 180f) {
                        rotAngle -= 360f;
                    }
                    Vector3 angularVelocity = (0.9f * Mathf.Deg2Rad * rotAngle / Time.deltaTime) * rotAxis.normalized;
                    rb.angularVelocity = angularVelocity;
                }
            }
        }
    }

    private void startInteraction(GameObject hand) {
        fulcrumOffset = 0.3f;
        originalPhysicsLayer = this.gameObject.layer;
        interactionActive = true;
        dominantHand = hand.GetComponent<HandPhysics>();
        rb.useGravity = false;
        this.gameObject.layer = hand.layer;
        right = true;
        //right = dominantHand.isRight();
    }
    
    private void endInteraction() {
        fulcrumOffset = 0f;
        this.gameObject.layer = originalPhysicsLayer;
        interactionActive = false;
        rb.useGravity = true;
    }

    public void addHand(GameObject hand) {
        if (interactionActive) {
            secondaryHand = hand.GetComponent<HandPhysics>();
        } else {
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
