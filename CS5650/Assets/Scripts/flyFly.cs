using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flyFly : MonoBehaviour
{
    //public GameObject fly;
    float speed;
    // Start is called before the first frame update
    void Start()
    {
        //start position
        transform.position = new Vector3(470.8f, 45.9f, 438.4f);
        speed = 0.4f;
    }

    // Update is called once per frame
    void Update()
    {
        //lerp to 499.53, 6.73, 409.7
        Vector3 finalPosition = new Vector3(499.53f, 6.73f, 409.7f);
        transform.position = Vector3.Lerp(transform.position, finalPosition, speed * Time.deltaTime);
    }
}
