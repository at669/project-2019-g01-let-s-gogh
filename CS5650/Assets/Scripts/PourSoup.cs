using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PourSoup : MonoBehaviour
{
    public GameObject soupInCan;
    //[SerializeField]
    ParticleSystem smolSoup;
    public GameObject Soup;
    //private IEnumerator coroutine;
    //GameObject pour;
    bool finishedPouring;
    // Start is called before the first frame update
    //once the rotation of the hits a certain point, turn on the soup particle system with the y rotation the same as the can
    void Start()
    {
        //soup = GetComponent<ParticleSystem>();
        //coroutine = PourDaSoup(0.3f);
        //soup.SetActive(false);
        smolSoup = Soup.GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        soupInCan.transform.position = transform.position;
        soupInCan.transform.rotation = transform.rotation;
        if (transform.rotation != Quaternion.identity)
        {
            float decrease = 0.001f;
            if (soupInCan.transform.localScale.y > 0.0001f)
            {
                soupInCan.transform.localScale = new Vector3(soupInCan.transform.localScale.x, soupInCan.transform.localScale.y - decrease, soupInCan.transform.localScale.z);
                finishedPouring = false;
                Debug.Log("still pouring");
            }
            else
            {
                finishedPouring = true;
                Soup.SetActive(false);
                Debug.Log("finished");
            }
        }
        if (!finishedPouring)
        {
            //StartCoroutine(coroutine);
            Soup.SetActive(true);
        }
    }

//    private IEnumerator PourDaSoup(float waitTime)
//    {
//        soup.SetActive(true);
        //soup.transform.position = new Vector3(transform.position.x, transform.position.y + 0.1f, transform.position.z);
        //soup.transform.rotation = transform.rotation; 
//        pouring = true;
//        yield return new WaitForSeconds(waitTime);
//    }
}
