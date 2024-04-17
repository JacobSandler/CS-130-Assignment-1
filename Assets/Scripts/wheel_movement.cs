using UnityEngine;
using UnityEngine.InputSystem;

public class VehicleController : MonoBehaviour
{
    public WheelCollider frontLeftWheel, frontRightWheel;
    public WheelCollider rearLeftWheel, rearRightWheel;

    public float maxMotorTorque = 1500f; // Maximum torque the motor can apply to wheel
    public float maxSteeringAngle = 30f; // Maximum steer angle the wheel can have

    float forward_input = 0f;    // Forward throttle input
    float steering_input = 0f;   // Steering input



    private void FixedUpdate()
    {
        float motor = maxMotorTorque * forward_input;
        float steering = maxSteeringAngle * steering_input;

        frontLeftWheel.motorTorque = motor;
        frontRightWheel.motorTorque = motor;
        rearLeftWheel.motorTorque = motor;
        rearRightWheel.motorTorque = motor;

        frontLeftWheel.steerAngle = steering;
        frontRightWheel.steerAngle = steering;
    }

    void OnMove(InputValue value)
    {
        Vector2 input = value.Get<Vector2>();
        UnityEngine.Debug.Log(input);
        forward_input = input.x;
        steering_input = input.y;
    }
}
