using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XRUtils {

  public void TransformRigidbody(Rigidbody rb, Vector3 position, Quaternion rotation) {
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
      if (!float.IsInfinity(rotAxis.x) && !float.IsNaN(rotAngle)) {
        if (rotAngle > 180f) {
          rotAngle -= 360f;
        }
        Vector3 angularVelocity = (0.9f * Mathf.Deg2Rad * rotAngle / Time.deltaTime) * rotAxis.normalized;
        rb.angularVelocity = angularVelocity;
      }
    }
  }

  public void setPhysicsLayer(int index, GameObject target) {
    setPhysicsLayer(index, target.transform);
  }

  public void setPhysicsLayer(int index, Transform target) {
    target.gameObject.layer = index;
    foreach (Transform transform in target.transform) {
      setPhysicsLayer(index, transform);
    }
  }
}