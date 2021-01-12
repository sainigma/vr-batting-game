using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerXRInit : MonoBehaviour
{
    public GameObject PhysicsHandPrefab;
    void Start() {
        if (UnityEngine.XR.XRSettings.enabled) {
            spawnHand(false);
            spawnHand(true);
        }
    }

    private void spawnHand(bool right) {
        GameObject handTarget = transform.Find("Offset")
            .Find(right ? "RHandTarget" : "LHandTarget").gameObject;
        GameObject hand = Instantiate(PhysicsHandPrefab, new Vector3(), new Quaternion());
        HandPhysics handPhysics = hand.GetComponent<HandPhysics>();
        handPhysics.setHandTarget(handTarget, right);
    }
}
