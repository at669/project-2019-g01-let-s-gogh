using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clankClonk : MonoBehaviour
{
    GameObject can;
    AudioSource canDrop;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        canDrop = can.GetComponent<AudioSource>();
        //if the can hits the floor then:
        if (!canDrop.isPlaying)
        {
            canDrop.Play();
            Debug.Log("clink clank");
        }
    }
}
