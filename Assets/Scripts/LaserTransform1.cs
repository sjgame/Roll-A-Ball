using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTransform1 : MonoBehaviour
{
    //sets the distance the object will move
    [SerializeField] float distanceToCover;
    //sets the speed the object will move
    [SerializeField] float speed;
    //sets where the object will start moving from 
    private Vector3 startingPosition;
    
    void Start()
    {
        startingPosition = transform.position;
    }

    
    void Update()
    {
        Vector3 y = startingPosition;
        y.z += distanceToCover * Mathf.Sin(Time.time * speed);
        transform.position = y; 
    }
}
