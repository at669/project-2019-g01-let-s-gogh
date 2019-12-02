using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PourSoup : MonoBehaviour
{
    public GameObject soupInCan;
    //[SerializeField]
    public ParticleSystem smolSoup;
    public GameObject Soup;
    public GameObject SoupSpherePrefab;
    public GameObject bowl;
    public GameObject BowlSoup;
    public GameObject cap;
    bool finishedPouring = true;
    // Start is called before the first frame update
    void Start()
    {        
        soupInCan.transform.position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        soupInCan.transform.rotation = transform.rotation;
        cap.transform.position = transform.position;
        cap.transform.rotation = transform.rotation;
        if (transform.rotation != Quaternion.identity)
        {
            float decrease = 0.001f;
            Debug.Log(soupInCan.transform.localScale.y);
            if (soupInCan.transform.localScale.y > 0.001f)
            {
                soupInCan.transform.localScale = new Vector3(soupInCan.transform.localScale.x, soupInCan.transform.localScale.y - decrease, soupInCan.transform.localScale.z);
                //soupInCan.transform.position = new Vector3(transform.position.x, soupInCan.transform.position.y - decrease/10, transform.position.z);
                finishedPouring = false;
                //Debug.Log("what is happening");
            }
            else
            {
                finishedPouring = true;
                Soup.SetActive(false);
                //Debug.Log("finished");
            }
        }
        else
        {
            finishedPouring = true;
            Soup.SetActive(false);
        }

        if (!finishedPouring)
        {
            Soup.SetActive(true);
            if (smolSoup.transform.position.x > bowl.transform.position.x - 0.15f && smolSoup.transform.position.x < bowl.transform.position.x + 0.15f)
            {
                if (smolSoup.transform.position.z > bowl.transform.position.z - 0.15f && smolSoup.transform.position.z < bowl.transform.position.z + 0.15f)
                {
                    Vector3 soupPosition = new Vector3(bowl.transform.position.x, bowl.transform.position.y + 0.1f, bowl.transform.position.z);
                    Instantiate(SoupSpherePrefab, soupPosition, Quaternion.identity);
                }
            }
        }
    }
}
