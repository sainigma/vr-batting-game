using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class VRMovement : MonoBehaviour
{
    private bool XREnabled;
    private InputDevice leftController;
    private InputDevice rightController;
    private PlayerMovement playerMovement;

    void Start()
    {
        XREnabled = UnityEngine.XR.XRSettings.enabled;
        if (XREnabled) {
            XRInit();
        }
    }

    private void XRInit() {
        var devices = new List<InputDevice>();
        UnityEngine.XR.InputDevices.GetDevicesWithCharacteristics(InputDeviceCharacteristics.Left, devices);
        leftController = devices[0];
        UnityEngine.XR.InputDevices.GetDevicesWithCharacteristics(InputDeviceCharacteristics.Right, devices);
        rightController = devices[0];
        playerMovement = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        if (!XREnabled) {
            return;
        }
        Vector2 movementControl;
        Vector2 rotationControl;
        leftController.TryGetFeatureValue(CommonUsages.primary2DAxis, out movementControl);
        rightController.TryGetFeatureValue(CommonUsages.primary2DAxis, out rotationControl);
        playerMovement.setMovement(movementControl);
        playerMovement.rotate(rotationControl);
    }
}
