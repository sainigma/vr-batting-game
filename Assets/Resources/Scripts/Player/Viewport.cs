using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Viewport : MonoBehaviour
{
    private bool XREnabled;
    private InputDevice headset;
    private Vector3 initialPosition;
    private float angle = 0f;
    void Start()
    {
        XREnabled = XRSettings.enabled;
        if (XREnabled) {
            XRInit();
        } else {
            this.transform.localPosition = new Vector3(0, 1.76f, 0);
        }
    }

    private void recenter() {
        if (!XREnabled) {
            return;
        }
        headset.subsystem.TryRecenter();
        headset.TryGetFeatureValue(CommonUsages.devicePosition, out initialPosition);
    }

    private void XRInit() {
        var devices = new List<InputDevice>();
        UnityEngine.XR.InputDevices.GetDevicesWithCharacteristics(InputDeviceCharacteristics.HeadMounted, devices);
        headset = devices[0];
        recenter();
    }

    private void XRUpdate() {
        Vector3 position;
        Quaternion rotation;
        headset.TryGetFeatureValue(CommonUsages.devicePosition, out position);
        headset.TryGetFeatureValue(CommonUsages.deviceRotation, out rotation);
        this.transform.localRotation = rotation;
        this.transform.localPosition = position - initialPosition;
    }

    private void flatUpdate() {
        this.transform.localRotation = Quaternion.Euler(angle,0,0);
    }

    public void setAngle(float newAngle) {
        angle += newAngle;
    }

    void Update()
    {
        if (XREnabled) {
            XRUpdate();
        } else {
            flatUpdate();
        }
    }
}
