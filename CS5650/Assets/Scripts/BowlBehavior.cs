using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlBehavior : MonoBehaviour
{
    bool startFilling;
    public GameObject SoupSpherePrefab;
    public GameObject bowl;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (startFilling)
        {
            Vector3 soupPosition = new Vector3(bowl.transform.position.x, bowl.transform.position.y + 0.05f, bowl.transform.position.z);
            Instantiate(SoupSpherePrefab, soupPosition, Quaternion.identity);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("soupParticles"))
        {
            startFilling = true;
        }
        else
        {
            startFilling = false;
        }
    }
}
