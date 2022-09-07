using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController3 : MonoBehaviour
{

    #region STRUCTURES
    public enum Axie
    {
        Front,
        Rear
    }

    [Serializable]
    private struct Wheel
    {
        public GameObject wheelModel;
        public WheelCollider wheelCollider;
        public Axie axie;
    }
    #endregion

    #region EXPOSED_FIELDS

    [SerializeField] private float forceAcceleration = 600.0f;

    [SerializeField] private float maxSteerAngle = 30.0f;

    [SerializeField] private bool inputEnabled = true;

    [SerializeField] private List<Wheel> _wheels;

    #endregion

    #region PRIVATE_FIELDS
    private float moveInput;
    private float steerInput;
    private Rigidbody carRb;
    #endregion

    #region UNITY_CALLS
    private void Start()
    {
        if (carRb == null)
            carRb = GetComponent<Rigidbody>();
        carRb.centerOfMass = Vector3.zero;
    }
    private void Update()
    {
        GetInput();
        AnimationWheel();
    }
    private void FixedUpdate()
    {
        Move();
        Steer();
    }
    #endregion

    #region PRIVATE_METHODS
    private void GetInput()
    {
        if (!inputEnabled)
            return;
        moveInput = Input.GetAxis("Vertical");
        steerInput = Input.GetAxis("Horizontal");
    }

    private void Move()
    {
        foreach (var item in _wheels)
        {
            item.wheelCollider.motorTorque = moveInput * forceAcceleration * Time.deltaTime;
        }
    }


    private void Steer()
    {
        foreach (var wheel in _wheels)
        {
            if (wheel.axie == Axie.Front)
            {
                var _steerAngle = steerInput * maxSteerAngle;
                wheel.wheelCollider.steerAngle = Mathf.Lerp(wheel.wheelCollider.steerAngle, _steerAngle, 0.6f);
            }
        }
    }

    private void AnimationWheel()
    {
        foreach (var wheel in _wheels)
        {
            Quaternion rot;
            Vector3 pos;
            wheel.wheelCollider.GetWorldPose(out pos, out rot);
            wheel.wheelModel.transform.position = pos;
            wheel.wheelModel.transform.rotation = rot;
        }
    }

    #endregion
}