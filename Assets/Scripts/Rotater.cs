using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotater : MonoBehaviour
{
    //changes speed x 10
    public float speed = 10f; 

    void Update()
    {
        //Roatate our object around an axis over time 
        transform.Rotate(new Vector3(0, 10, 0) * Time.deltaTime * speed, Space.World ); 

    }
}
