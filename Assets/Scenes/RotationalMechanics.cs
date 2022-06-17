using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RotationalMechanics
{
    private const float PI = 3.14159265F;

    public float calculatingTorque(float r, float f, float pHI)
    {
        return  r * f * (float) Mathf.Sin(pHI * PI/(float)180.0f);
    }

    public float momentOfInertia(float m, float r)
    {
        return (float) m * r * r;
    }

    public float computeConstantAngularAcceleration(float I, float T)
    {
        return (float)T / (float)I;
    }

    public float computeAngularVelocity(float omega0, float alpha, float t)
    {
        return omega0 + alpha * t;
    }

    public float computeAngularDisplacement(float thetha0, float Omega0, float alpha, float t)
    {
        return thetha0 + Omega0 * t + (1 / (float)2) * alpha * t * t;
    }

    public Vector3 computeNextObjectPositionAlongCircularPath(float theta0, float r, Vector3 centre)
    {
        float updatedXCoordinate = (float) centre.x + r * (float) Mathf.Cos(theta0);
        float updatedYCoordinate = (float) centre.z + r * (float) Mathf.Sin(theta0);
        return new Vector3(updatedXCoordinate, updatedYCoordinate);
    }
}
