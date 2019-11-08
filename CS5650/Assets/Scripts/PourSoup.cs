using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PourSoup : MonoBehaviour
{
    public GameObject soupInCan;
    public GameObject soup;
    GameObject pour;
    bool pouring = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        soupInCan.transform.position = transform.position;
        soupInCan.transform.rotation = transform.rotation;
        if (transform.rotation != Quaternion.identity)
        {
            
            float decrease = 0.05f;
            if (soupInCan.transform.localScale.y > 0)
            {
                soupInCan.transform.localScale = new Vector3(soupInCan.transform.localScale.x, soupInCan.transform.localScale.y - decrease, soupInCan.transform.localScale.z);
                pouring = false;
            }


        }
        if (!pouring)
        {
            Vector3 soupPos = new Vector3(transform.position.x, transform.position.y + 0.1f, transform.position.z);
            pour = Instantiate(soup, soupPos, transform.rotation);
            pouring = true;
        }
        if (soupInCan.transform.localScale.y < 0.001f)
        {
            Destroy(pour);
        }
    }
}
