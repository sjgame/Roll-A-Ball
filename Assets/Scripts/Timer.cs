using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [Header("Component")]
    public TextMeshProUGUI timerText;

    [Header("Timer Settings")]
    public float currentTime;
    public bool countDown; //This is to make the counter descend 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Gets the current time though Time.deltaTime and determines whether it goes up or down
        currentTime = countDown ? currentTime -= Time.deltaTime : currentTime += Time.deltaTime;
        //Sets the timerText using the currentTime as a string
        timerText.text = "Time: " + currentTime.ToString("0.00");
    }

     
}
