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
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("floor"))
        {
            hitGround = true;
        }
    }

    void Update()
    {
        //if the can hits the floor then:
        if (hitGround)
        {
            if (!canDrop.isPlaying)
            {
                canDrop.Play();
                hitGround = false;
            }
        }
    }
}
