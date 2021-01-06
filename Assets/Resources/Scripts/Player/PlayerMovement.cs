using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public bool directControl;
    private Vector2 movement;
    private Viewport viewport;
    private CharacterController characterController;
    private PlayerController playerController;
    private bool XREnabled;

    [Header("Movement constants")]
    public float maxSpeed;
    public float maxRotationSpeed;

    void Start() {
        characterController = GetComponent<CharacterController>();
        viewport = transform.Find("Offset").Find("Viewport").GetComponent<Viewport>();
    }

    private void Awake() {
        if (directControl) {
            XREnabled = UnityEngine.XR.XRSettings.enabled;
            playerController = new PlayerController();
        }
    }

    private void OnEnable() {
        if (directControl) {
            playerController.Enable();
        }
    }

    private void OnDisable() {
        if (directControl) {
            playerController.Disable();
        }
    }

    public void rotate(Vector2 rotation) {
        this.transform.Rotate(new Vector3(0, rotation.x * maxRotationSpeed, 0), Space.Self);
        if (!XREnabled) {
            viewport.setAngle(rotation.y * maxRotationSpeed);
        }
    }

    private void move(Vector2 finalMovement) {
        Vector3 movementSum = new Vector3(0, -9.81f, 0);
        if (finalMovement.magnitude > 0.01f) {
            movementSum += finalMovement.y * this.transform.forward + finalMovement.x * this.transform.right; 
        }
        characterController.Move(movementSum * Time.deltaTime);
    }

    public void setMovement(Vector2 newMovement) {
        movement = newMovement;
    }

    void Update() {
        if (directControl) {
            Vector2 inputMovement = playerController.FirstPersonPlayer.movement.ReadValue<Vector2>();
            Vector2 inputRotation = playerController.FirstPersonPlayer.look.ReadValue<Vector2>();
            move(inputMovement);
            rotate(inputRotation);
        } else {
            move(movement);
        }
    }
}