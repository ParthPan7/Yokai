using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static RotationalMechanics;
public class PebbleMovement : MonoBehaviour
{
    [SerializeField]
    private float slingRadius;

    [SerializeField]
    private float approximateForceOnPebble;

    [SerializeField]
    private float angleOfForce;

    [SerializeField]
    private float mass;

    [SerializeField]
    private float approximatedRadiusOfIrregularPebble;

    private float angularAcceleration;

    private Vector3 pebblePosition, centre;

    private RotationalMechanics rotationalMechanics;

    private float torque, momentOfInteria, computedAngularDisplacement, angularVelocity, angularDisplacement;

    public Vector3 hand;
    // Start is called before the first frame update
    void Start()
    {
        pebblePosition = gameObject.transform.position;
        Debug.Log("Pebble Position : x " + pebblePosition.x + " y " + pebblePosition.y);
        rotationalMechanics = new RotationalMechanics();
        torque = rotationalMechanics.calculatingTorque(slingRadius, approximateForceOnPebble, angleOfForce);
        Debug.Log("Torque : " + torque);
        momentOfInteria = rotationalMechanics.momentOfInertia(mass, approximatedRadiusOfIrregularPebble);
        Debug.Log("Moment of Interia: " + momentOfInteria);
        angularAcceleration = rotationalMechanics.computeConstantAngularAcceleration(momentOfInteria, torque);
        Debug.Log("Angular Acceleration: " + (float) angularAcceleration);
        angularVelocity = 0.0f;
        angularDisplacement = 0.0f;
        hand = GameObject.FindGameObjectWithTag("Hand").transform.position;
        float x = hand.x;
        float y = hand.y;
        float z = hand.z;
        centre = new Vector3(x, y, z); 
    }

    // Update is called once per frame
    void Update()
    {
        angularVelocity = rotationalMechanics.computeAngularVelocity(angularVelocity, angularAcceleration, Time.deltaTime);
        angularDisplacement = rotationalMechanics.computeAngularDisplacement(angularDisplacement, angularVelocity, angularAcceleration, Time.deltaTime);
        Vector3 updatedPebblePosition = rotationalMechanics.computeNextObjectPositionAlongCircularPath(angularDisplacement, slingRadius, centre);
        Vector3 actualPebblePosition = new Vector3(updatedPebblePosition.x, transform.position.y, updatedPebblePosition.y);
        Debug.Log("Updated Pebble Position " + actualPebblePosition);
        transform.position = actualPebblePosition;
    }
}
