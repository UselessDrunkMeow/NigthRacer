using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    //https://www.youtube.com/watch?v=Z4HA8zJhGEk tutorial

    //https://forum.unity.com/threads/how-to-make-a-physically-real-stable-car-with-wheelcolliders.50643/?_ga=2.258903491.890050916.1642672854-1275429231.1604914616 mis hanig

    [Header("Steering Variables")]
    private const string _HORIZONTAL = "Horizontal";
    private const string _VERTICAL = "Vertical";
    private float _HorizontalInput;
    private float _VerticalInput;

    [Header("Current Variables")]
    private float _CurrnetSteerAngle;
    private float _CurrentBreakForce;
    private bool _IsBreaking;


    [Header("RigidBody")]
    public Rigidbody _rb;
        
    [Header("Driving/Steering Variables")]
    [SerializeField] private float _BreakForce;
    [SerializeField] private float _MotorForce;
    [SerializeField] private float _MaxSteeringAngle;

    [Header("Speed Variables")]
    [SerializeField] public float _Speed;
        
    [Header("Wheel Colider")]
    [SerializeField] private WheelCollider _FLwheelCollider;
    [SerializeField] private WheelCollider _FRwheelCollider;
    [SerializeField] private WheelCollider _BLwheelCollider;
    [SerializeField] private WheelCollider _BRwheelCollider;

    [Header("Wheel Models")]
    [SerializeField] private Transform _FLwheelTransform;
    [SerializeField] private Transform _FRwheelTransform;
    [SerializeField] private Transform _BLwheelTransform;
    [SerializeField] private Transform _BRwheelTransform; 

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        _Speed = _rb.velocity.magnitude * 2;
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
    }

    private void GetInput()//Gets the inputs and stores them
    {
        _HorizontalInput = Input.GetAxis(_HORIZONTAL);
        _VerticalInput = Input.GetAxis(_VERTICAL);
        _IsBreaking = Input.GetKey(KeyCode.Space);
    }
    private void HandleMotor()//handels everything the motor needs to do, like driving and breaking
    {        
        _BLwheelCollider.motorTorque = _VerticalInput * _MotorForce;        
        _BRwheelCollider.motorTorque = _VerticalInput * _MotorForce;
        _CurrentBreakForce = _IsBreaking ? _BreakForce : 0f;
        if (!_IsBreaking)
        {
            _FRwheelCollider.brakeTorque = _FLwheelCollider.brakeTorque = _BRwheelCollider.brakeTorque = _BLwheelCollider.brakeTorque = 0f;
        }
        ApplyBreaking();
    }
    private void ApplyBreaking()//applys the brackfore to all of the wheels
    {
        //_FLwheelCollider.brakeTorque = _CurrentBreakForce;
        //_FRwheelCollider.brakeTorque = _CurrentBreakForce;
        _BLwheelCollider.brakeTorque = _CurrentBreakForce;
        _BRwheelCollider.brakeTorque = _CurrentBreakForce;
    }
    private void HandleSteering()//handels the steering 
    {
        _CurrnetSteerAngle = _MaxSteeringAngle * _HorizontalInput;
        _FLwheelCollider.steerAngle = _CurrnetSteerAngle;
        _FRwheelCollider.steerAngle = _CurrnetSteerAngle;
    }
    
}
