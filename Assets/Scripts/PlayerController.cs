using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    public float speed = 1.0f;
    bool grounded = true;
   

    public int pickupCount; //Stores pickup count (variable)
    int totalPickups;
    private bool wonGame = false;
    [Header("UI")]
    public TMP_Text scoreText;
    public TMP_Text winText;
    public GameObject inGamePanel;
    public GameObject winPanel;
    public Image pickupFill;
    public float pickupChunk;
    public Image controlsPopup; //Stores 
    void Start()
    {
        //Turn off our win panel object
        winPanel.gameObject.SetActive(false);

        //Turn on ingame panel
        inGamePanel.SetActive(true);

        //Activates the controls popup (When game starts)
        controlsPopup.gameObject.SetActive(true);
        
        //Gets the rigidbody component attached to this game object
        rb = GetComponent<Rigidbody>();

        //Work out how many pickups are in the scene and store in (pickupCount)
        pickupCount = GameObject.FindGameObjectsWithTag("Pickup").Length;

        //Assign the amount of pickups to the total pickups
        totalPickups = pickupCount;

        //Work out the amount of fill for our pickup fill (image)
        pickupChunk = 1.0f / totalPickups;
        pickupFill.fillAmount = 0;

        //Display the pickups to the user
        CheckPickups();
    }

    private void Update()
    {
        //Turn off the control popup
        if (Input.anyKey)
        {
            controlsPopup.gameObject.SetActive(false);
        }
            

    }
  
void FixedUpdate()

    {
         if (wonGame) //Disables player controls if (wonGame = true) returns function 
            return;

        if (grounded)
        {
            //Store the horizontal axis value in a float 
            float moveHorizontal = Input.GetAxis("Horizontal");
            //Store the vertical axis value in a float 
            float moveVertical = Input.GetAxis("Vertical");

            //Create a new vector 3 based on the horizontal and vertical values
            Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);

            //Add force to our rigidbody from our movement vector times our speed
            rb.AddForce(movement * speed);
        }


    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.CompareTag("Ground"));
        grounded = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("Ground"));
        grounded = false;
    }


    public bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, 1.0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        //if we trigger a pickup, destroy the pickup    
        if (other.gameObject.CompareTag("Pickup"))
        {
            //Decrement the pickupCount when we collide with a pickup
            pickupCount -= 1;

            //Increase the fill amount of our pickup fill image
            pickupFill.fillAmount = pickupFill.fillAmount + pickupChunk;

            CheckPickups();



            
        }

        //Create a win condition that happens when pickup count == 0

    }

    void CheckPickups()
    {
        //Display the new pickup count to the player
        scoreText.text = "Pickups Left: " + pickupCount.ToString() + "/" + totalPickups.ToString();

        //Check if the pickupCount == 0
        if (pickupCount == 0)
        {
            //if pickupCount == 0, display win message
            winPanel.gameObject.SetActive(true);

            inGamePanel.SetActive(false);
            //Remove controls from player
            wonGame = true;
            //Set the velocity of the rigidBody to 0
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }


    }

    //Temporary reset functionality

    public void ResetGame()

    {
        UnityEngine.SceneManagement.SceneManager.LoadScene
            (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }
}
