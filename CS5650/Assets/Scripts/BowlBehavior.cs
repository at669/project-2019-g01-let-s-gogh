using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlBehavior : MonoBehaviour
{
    bool startFilling;
    public GameObject BowlSoup;
    public GameObject bowl;
    public ParticleSystem smolSoup;
    public GameObject SoupSpherePrefab;
    // Start is called before the first frame update
    void Start()
    {
        Physics.IgnoreLayerCollision(5, 9);
        //smol = smolSoup.GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        //ignore bowl collision (make another layer)
        //Physics.IgnoreLayerCollision(7,9);
        if (smolSoup.transform.position.x > bowl.transform.position.x - 0.1f && smolSoup.transform.position.x < bowl.transform.position.x + 0.1f)
        {
            if (smolSoup.transform.position.z > bowl.transform.position.z - 0.1f && smolSoup.transform.position.z < bowl.transform.position.z + 0.1f)
            {
                startFilling = true;
                Debug.Log("ya");
            }
        }
        if (startFilling)
        {
            Vector3 soupPosition = new Vector3(bowl.transform.position.x, bowl.transform.position.y + 0.05f, bowl.transform.position.z);
            Instantiate(SoupSpherePrefab, soupPosition, Quaternion.identity);
            BowlSoup.transform.localScale = new Vector3(BowlSoup.transform.localScale.x + 0.001f, BowlSoup.transform.localScale.y, BowlSoup.transform.localScale.z + 0.001f);
            BowlSoup.transform.position = new Vector3(bowl.transform.position.x, bowl.transform.position.y + 0.0001f, bowl.transform.position.z);

            Debug.Log("prefab instantiated");
        }
        else
        {
            Debug.Log("nope");
        }
    }
    //private void OnParticleCollision(GameObject other)
    //{
      //  Debug.Log(other.tag);
        //startFilling = true;
    //}
}
