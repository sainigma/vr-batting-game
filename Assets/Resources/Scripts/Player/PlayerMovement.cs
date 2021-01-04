using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 movement;
    private Viewport viewport;
    private CharacterController characterController;

    [Header("Movement constants")]
    public float maxSpeed;
    public float maxRotationSpeed;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        viewport = transform.Find("Offset").Find("Viewport").GetComponent<Viewport>();
        Debug.Log(viewport);
    }

    public void setMovement(Vector2 newMovement) {
        movement = newMovement;
    }

    public void rotate(Vector2 rotation) {
        this.transform.Rotate(new Vector3(0, rotation.x * maxRotationSpeed, 0), Space.Self);
        viewport.setAngle(rotation.y * maxRotationSpeed);
    }

    void Update()
    {
        Vector3 movementSum = new Vector3(0, -9.81f, 0);
        if (movement.magnitude > 0.01f) {
            movementSum += movement.y * this.transform.forward + movement.x * this.transform.right; 
        }
        characterController.Move(movementSum * Time.deltaTime);
    }
}
