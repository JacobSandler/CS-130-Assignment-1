using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class car_movement : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rb;
    float speed = 5f;           // Speed of forward movement
    float rotationSpeed = 100f; // Speed of steering
    float forward_input = 0f;    // Forward throttle input
    float steering_input = 0f;   // Steering input
    bool on_ground = true;
    public int boosts = 3;

    public Transform[] wheels;
    public LayerMask groundLayer;

    private float raycastLength = 0.7f;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }


    // Update is called once per frame
    void Update()
    {
        int wheels_on_ground = 0;
        foreach (Transform wheel in wheels)
        {
            // Cast a ray downwards from the wheel position
            RaycastHit hit;
            Vector3 raycastOrigin = wheel.position;
            Vector3 raycastDirection = -wheel.up;

            if (Physics.Raycast(wheel.position, -wheel.up, out hit, raycastLength, groundLayer))
            {
                // If the ray hits something on the ground layer, the wheel is touching the ground
                //Debug.Log("Wheel touching ground: " + wheel.name);
                wheels_on_ground += 1;
            }
            else
            {
                // If the ray doesn't hit anything on the ground layer, the wheel is not touching the ground
                //Debug.Log("Wheel not touching ground: " + wheel.name);
                on_ground = false;
            }

            //Debug.DrawRay(raycastOrigin, raycastDirection * raycastLength, Color.red);

        }

        if (wheels_on_ground >= 3)
        {
            on_ground = true;
        }
        else
        {
            on_ground = false;
        }

        if (on_ground)
        {
            // transform.position += direction * Time.deltaTime;
            if (rb.velocity.magnitude < 20)
            {
                rb.AddForce(transform.right * forward_input * speed);
            }

        }

        float turn = steering_input * rotationSpeed * Time.deltaTime;
        Quaternion rotation = Quaternion.Euler(0f, turn, 0f);
        //rb.MoveRotation(rb.rotation * rotation);
        transform.Rotate(Vector3.up, turn * rotationSpeed * Time.deltaTime, Space.Self);
        //Debug.Log("Center/Position of the object: " + transform.position);
        


    }

    void OnMove(InputValue value)
    {
        Vector2 input = value.Get<Vector2>();
        UnityEngine.Debug.Log(input);
        forward_input = input.y;
        steering_input = input.x;
    }

    void OnJump(InputValue value)
    {
        if (!on_ground) { return; }
        Vector3 jumpforce = new Vector3(0, 300, 0);
        rb.AddForce(jumpforce);
    }

    void OnFire(InputValue value)
    {
        if (boosts > 0)
        {
            Vector3 boost = new Vector3(1000, 0, 0);
            rb.AddForce(boost);
            boosts -= 1;
        }

    }
}

