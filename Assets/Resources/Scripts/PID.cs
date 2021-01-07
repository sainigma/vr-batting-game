using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PID : MonoBehaviour
{
    float errorSum, previousError;
    float P, I, D;

    public PID(float P, float I, float D) {
        this.P = P;
        this.I = I;
        this.D = D;
        errorSum = 0;
        previousError = 0;
    }

    public float getControl(float error) {
        float dt = Time.deltaTime;
        errorSum += error * dt;
        float errorSlope = previousError == 0 ? 0 : (error - previousError) / dt;
        float control = P * error + I * errorSum + D * errorSlope;
        previousError = error;
        return control;
    }
}
