using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ground_check : MonoBehaviour
{
    // Start is called before the first frame update
    public WheelCollider[] wheel_colliders;
    public bool is_grounded { get; private set; }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        is_grounded = true;
        foreach (WheelCollider wheel in wheel_colliders)
        {
            if (!wheel.isGrounded)
            {
                is_grounded=false;
                Debug.Log("NOT GROUNDED");
                break;
            }
        }
    }
}
