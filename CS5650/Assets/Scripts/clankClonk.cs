using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clankClonk : MonoBehaviour
{
    //GameObject can;
    AudioSource canDrop;
    bool hitGround;
    // Start is called before the first frame update
    void Start()
    {
        canDrop = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("floor"))
        {
            hitGround = true;
            Debug.Log("floor detected");
        }
    }
    void Update()
    {
        
        Debug.Log(hitGround);
        //if the can hits the floor then:
        if (hitGround)
        {
            if (!canDrop.isPlaying)
            {
                canDrop.Play();
                Debug.Log("clink clank");
                hitGround = false;
            }
        }
    }
}
