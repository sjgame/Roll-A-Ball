using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falling_Rocks : MonoBehaviour
{
    public GameObject fallingRock;

    public Vector3 startingPosition;
    public Rigidbody rb;

   
   
    


    void Start()
    {
        startingPosition = transform.position;
    }
    private void OnTriggerEnter (Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            rb.isKinematic = false;
        }
    }
}
