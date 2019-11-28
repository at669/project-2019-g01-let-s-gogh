using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PourSoup : MonoBehaviour
{
    public GameObject soupInCan;
    //[SerializeField]
    ParticleSystem smolSoup;
    public GameObject Soup;
    bool finishedPouring = true;
    // Start is called before the first frame update
    void Start()
    {        
        smolSoup = Soup.GetComponent<ParticleSystem>();
        //Soup.transform.gameObject.SetActive(false);
        //transform.localRotation = Quaternion.identity;
    }

    // Update is called once per frame
    void Update()
    {
        soupInCan.transform.position = transform.position;
        soupInCan.transform.rotation = transform.rotation;
        //don't know if you can keep the puddle of particles in one spot while moving the base of the particle system...
        //Debug.Log(transform.localRotation);
        //Debug.Log(Quaternion.identity);
        if (transform.rotation != Quaternion.identity)
        {
            float decrease = 0.001f;
            Debug.Log(soupInCan.transform.localScale.y);
            if (soupInCan.transform.localScale.y > 0.001f)
            {
                soupInCan.transform.localScale = new Vector3(soupInCan.transform.localScale.x, soupInCan.transform.localScale.y - decrease, soupInCan.transform.localScale.z);
                finishedPouring = false;
                Debug.Log("what is happening");
            }
            else
            {
                finishedPouring = true;
                Soup.SetActive(false);
                Debug.Log("finished");
            }
        }
        else
        {
            finishedPouring = true;
            Soup.SetActive(false);
        }

        if (!finishedPouring)
        {
            //StartCoroutine(coroutine);
            Soup.SetActive(true);
            Debug.Log("Pouring????");
            //finishedPouring = true;
        }
    }
}
