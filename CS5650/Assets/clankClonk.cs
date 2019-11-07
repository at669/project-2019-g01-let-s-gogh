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
        
    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("floor"))
        {
            hitGround = true;
            Debug.Log("floor detected");
        }
    }
    void Update()
    {
        canDrop = GetComponent<AudioSource>();
        Debug.Log(canDrop);
        //if the can hits the floor then:
        if (hitGround)
        {
            if (!canDrop.isPlaying)
            {
                canDrop.Play();
                Debug.Log("clink clank");
            }
        }
    }
}
