using UnityEngine;
using System.Collections;

public class AntiRollBar : MonoBehaviour
{
    //https://gamedev.stackexchange.com/questions/118388/how-to-do-an-anti-sway-bar-for-a-car-in-unity-5
    public WheelCollider wheelL;
    public WheelCollider wheelR;
    public float antiRollVal = 5000f;
    Rigidbody _RB;
    // Use this for initialization
    void Start()
    {
        _RB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        WheelHit hit;
        float travelL = 1.0f;
        float travelR = 1.0f;
        bool groundedL = wheelL.GetGroundHit(out hit);
        if (groundedL)
        {
            travelL = (-wheelL.transform.InverseTransformPoint(hit.point).y - wheelL.radius) / wheelL.suspensionDistance;
        }
        bool groundedR = wheelR.GetGroundHit(out hit);
        if (groundedR)
        {
            travelR = (-wheelR.transform.InverseTransformPoint(hit.point).y - wheelR.radius) / wheelR.suspensionDistance;
        }

        float antiRollForce = (travelL - travelR) * antiRollVal;

        if (groundedL)

            _RB.AddForceAtPosition(wheelL.transform.up * -antiRollForce,

                   wheelL.transform.position);

        if (groundedR)

            _RB.AddForceAtPosition(wheelR.transform.up * antiRollForce,

                   wheelR.transform.position);
    }
}