using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;

public class moving_person : MonoBehaviour
{

    Rigidbody rb;
    float speed = 2f;
    Vector3 direction;
    bool on_ground = false;

    // Start is called before the first frame update
    void Start()
    {
       direction = Vector3.zero;
       rb = gameObject.GetComponent<Rigidbody>();
    }


    // Update is called once per frame
    void Update()
    {

        // transform.position += direction * Time.deltaTime;
        if (rb.velocity.magnitude < 10)
        {
            rb.AddForce(direction * speed);
        }
    }

    void OnMove(InputValue value)
    {
        Vector2 input = value.Get<Vector2>();
        UnityEngine.Debug.Log(input);
        float x_movement = input.x;
        float z_movement = input.y;

        direction = new Vector3(x_movement, 0, z_movement);
    }

    void OnJump(InputValue value)
    {
        if (!on_ground) { return; }
        Vector3 jumpforce = new Vector3(0, 100, 0);
        rb.AddForce(jumpforce);
    }

    private void OnCollisionEnter(Collision collision)
    {
        for (int i = 0; i < collision.contactCount; i++)
        {
            ContactPoint c = collision.contacts[i];
            float ratioInDirection = Vector3.Dot(Vector3.up, c.normal);
            if (ratioInDirection > 0.8) {
                on_ground = true;
            }
        }
    }

    private void OnCollisionExit(Collision collision) {
        for (int i = 0; i < collision.contactCount; i++)
        {
            ContactPoint c = collision.contacts[i];
            float ratioInDirection = Vector3.Dot(Vector3.up, c.normal);
            if (ratioInDirection > 0.8)
            {
                on_ground = false;
            }
        }
    }
}
