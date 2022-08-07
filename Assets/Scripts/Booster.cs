using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Booster : MonoBehaviour
{
    public Vector3 boostDirection = new Vector3(0, 1, 0);
    public float boostPower = 250;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            other.attachedRigidbody.AddForce(boostDirection * boostPower);
        }
    }
}
