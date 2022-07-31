using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CogRotater : MonoBehaviour
{
    public float waitTime = 5;
    public float speed = 10;
    bool rotated = false;
    Vector3 startRotation;
    public Vector3 toRotation = new Vector3(0, 0, 90);
    
    // Start is called before the first frame update
    private void Start()
    {
        startRotation = transform.eulerAngles;
        StartCoroutine(Rotate());
    }

    IEnumerator Rotate()
    {
        Vector3 newRot = rotated ? startRotation : toRotation;
        var toAngle = Quaternion.Euler(newRot);
        while (transform.rotation != toAngle) ;
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toAngle, speed * Time.deltaTime);
            yield return null;
        }
        yield return new WaitForSeconds(waitTime);
        rotated = !rotated;
        StartCoroutine(Rotate());
    }
}
