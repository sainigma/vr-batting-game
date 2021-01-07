using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class XRHand : MonoBehaviour
{
    public bool left;
    private bool XREnabled;
    private InputDevice hand;

    void Start() {
        XREnabled = XRSettings.enabled;
        if (!XREnabled) {
            return;
        }
        var devices = new List<InputDevice>();
        InputDeviceCharacteristics deviceCharesteristic = left ? InputDeviceCharacteristics.Left : InputDeviceCharacteristics.Right;
        UnityEngine.XR.InputDevices.GetDevicesWithCharacteristics(deviceCharesteristic, devices);
        hand = devices[0];
    }

    void Update() {
        if (!XREnabled) {
            return;
        }
        Vector3 position;
        Quaternion rotation;

        hand.TryGetFeatureValue(CommonUsages.devicePosition, out position);
        hand.TryGetFeatureValue(CommonUsages.deviceRotation, out rotation);
        
        this.transform.localRotation = rotation;
        this.transform.localPosition = position;
    }

    public float getGrip() {
        float grip;
        hand.TryGetFeatureValue(CommonUsages.grip, out grip);
        return grip;
    }

    public bool isRight() {
        return !left;
    }
}
