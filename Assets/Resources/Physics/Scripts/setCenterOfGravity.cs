using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class setCenterOfGravity : MonoBehaviour
{
    private Rigidbody rb;
    [Header("Center of Origin")]
    public Vector3 cog;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = cog;
    }


}

[CustomEditor(typeof(setCenterOfGravity))]
public class EditorHelpers : Editor {
    void OnSceneGUI() {
        setCenterOfGravity obj = (setCenterOfGravity)target;

        EditorGUI.BeginChangeCheck();
        Vector3 newCog = Handles.PositionHandle(obj.cog + obj.transform.position, Quaternion.identity);
        if (EditorGUI.EndChangeCheck()) {
            Undo.RecordObject(obj, "Change center of gravity");
            obj.cog = newCog - obj.transform.position;
        }
    }
}