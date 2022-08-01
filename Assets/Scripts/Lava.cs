using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Lava : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene("Schatzman_J_305083_AGA206_A1_Playable_Game");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
