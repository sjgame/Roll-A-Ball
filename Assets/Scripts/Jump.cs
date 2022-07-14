using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    private Rigidbody rb;
    public float jumpHeight = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Checks to see if the player is grounded, if they are, they can jump again
        if (IsGrounded() && Input.GetButtonDown("Jump"))
        {   
            rb.velocity = Vector3.up * jumpHeight; //Jump using a Vector 3 in the upwards direction multiplied by the set height
        }
    }
    public bool IsGrounded()
    {   //Grounds the player and tells the if statement if the player is grounded
        return Physics.Raycast(transform.position, Vector3.down, 1.0f);
    }
}
