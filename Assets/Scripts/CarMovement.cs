using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    //https://www.youtube.com/watch?v=Z4HA8zJhGEk tutorial

    //https://forum.unity.com/threads/how-to-make-a-physically-real-stable-car-with-wheelcolliders.50643/?_ga=2.258903491.890050916.1642672854-1275429231.1604914616 mis hanig
    private const string _HORIZONTAL = "Horizontal";
    private const string _VERTICAL = "Vertical";

    private float _HorizontalInput;
    private float _VerticalInput;
    private float _CurrnetSteerAngle;
    private float _CurrentBreakForce;
    private bool _IsBreaking;


    [SerializeField] private float _Speed;
    [SerializeField] private float _BreakForce;
    [SerializeField] private float _MotorForce;
    [SerializeField] private float _MaxSteeringAngle;

    [SerializeField] private WheelCollider _FLwheelCollider;
    [SerializeField] private WheelCollider _FRwheelCollider;
    [SerializeField] private WheelCollider _BLwheelCollider;
    [SerializeField] private WheelCollider _BRwheelCollider;

    [SerializeField] private Transform _FLwheelTransform;
    [SerializeField] private Transform _FRwheelTransform;
    [SerializeField] private Transform _BLwheelTransform;
    [SerializeField] private Transform _BRwheelTransform;

    float _CarRotationX;
    float _CarRotationY;
    float _CarRotationZ;


    private void Update()
    {
        if (transform.rotation.z >= 0.01f || transform.rotation.z <= -0.01f)
        {
            transform.rotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, 0);
        }
    }
    private void FixedUpdate()
    {
        GetInput();
        HandleMotor();  
        HandleSteering();
        UpdateWheels();
    }

    private void GetInput()
    {
        _HorizontalInput = Input.GetAxis(_HORIZONTAL);
        _VerticalInput = Input.GetAxis(_VERTICAL);
        _IsBreaking = Input.GetKey(KeyCode.Space);
    }
    private void HandleMotor()
    {
        //_FLwheelCollider.motorTorque = _VerticalInput * _MotorForce;
        _BLwheelCollider.motorTorque = _VerticalInput * _MotorForce;
        //_FRwheelCollider.motorTorque = _VerticalInput * _MotorForce;
        _BRwheelCollider.motorTorque = _VerticalInput * _MotorForce;
        _CurrentBreakForce = _IsBreaking ? _BreakForce : 0f;
        if (!_IsBreaking)
        {
            _FRwheelCollider.brakeTorque = _FLwheelCollider.brakeTorque = _BRwheelCollider.brakeTorque = _BLwheelCollider.brakeTorque = 0f;
        }
        ApplyBreaking();

    }
    private void ApplyBreaking()
    {
        _FLwheelCollider.brakeTorque = _CurrentBreakForce;
        _FRwheelCollider.brakeTorque = _CurrentBreakForce;
        _BLwheelCollider.brakeTorque = _CurrentBreakForce;
        _BRwheelCollider.brakeTorque = _CurrentBreakForce;
    }
    private void HandleSteering()
    {
        _CurrnetSteerAngle = _MaxSteeringAngle * _HorizontalInput;
        _FLwheelCollider.steerAngle = _CurrnetSteerAngle;
        _FRwheelCollider.steerAngle = _CurrnetSteerAngle;
    }
    private void UpdateWheels()
    {
        //UpdateSingleWheel(_FLwheelCollider, _FLwheelTransform);
        //UpdateSingleWheel(_FRwheelCollider, _FRwheelTransform);
        //UpdateSingleWheel(_BLwheelCollider, _BLwheelTransform);
        //UpdateSingleWheel(_BRwheelCollider, _BRwheelTransform);
    }

    private void UpdateSingleWheel(WheelCollider wheelCollider, Transform wheelTransform)
    {
        Vector3 pos;
        Quaternion rot;
        wheelCollider.GetWorldPose(out pos, out rot);
        wheelTransform.rotation = rot;
        wheelTransform.position = pos;
        rot.z = 90;
    }
}
