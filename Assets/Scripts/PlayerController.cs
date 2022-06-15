using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    public float speed = 1.0f;
    public int pickupCount; //Stores pickup count (variable)
    private bool wonGame = false; 

    void Start()
    {
        //Gets the rigidbody component attached to this game object
        rb = GetComponent<Rigidbody>();

        //Work out how many pickups are in the scene and store in (pickupCount)
        pickupCount = GameObject.FindGameObjectsWithTag("Pickup").Length;

        //Display the pickups to the user
        CheckPickups();
    }

    void FixedUpdate()

    {
        if (wonGame) //disables player controls if (wonGame = true) returns function 
            return;

        //Store the horizontal axis value in a float 
        float moveHorizontal = Input.GetAxis("Horizontal");
        //Store the vertical axis value in a float 
        float moveVertical = Input.GetAxis("Vertical");

        //Create a new vector 3 based on the horizontal and vertical values
        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);

        //Add force to our rigidbody from our movement vector times our speed
        rb.AddForce(movement * speed);

    }

    private void OnTriggerEnter(Collider other)
    {
        //if we trigger a pickup, destroy the pickup    
        if (other.gameObject.CompareTag("Pickup"))
        {
            //Decrement the pickupCount when we collide with a pickup
            pickupCount -= 1;
            CheckPickups();

            Destroy(other.gameObject);
        }

        //Create a win condition that happens when pickup count == 0

    }

    void CheckPickups()
    {
        //Display the new pickup count to the player
        Debug.Log("Pickups Remaining: " + pickupCount);
        //Check if the pickupCount == 0
        if (pickupCount == 0)
        {
            //if pickupCount == 0, display win message
            Debug.Log("You Win!");
            //Remove controls from player
            wonGame = true;
            //set the velocity of the rigidBody to 0
            rb.velocity = Vector3.zero;

        }
    }
}
