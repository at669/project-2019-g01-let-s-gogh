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
        Physics.IgnoreLayerCollision(5, 9);
    }

    // Update is called once per frame
    void Update()
    {
        //ignore bowl collision (make another layer)
        //Physics.IgnoreLayerCollision(7,9);
        if (startFilling)
        {
            Vector3 soupPosition = new Vector3(bowl.transform.position.x, bowl.transform.position.y + 0.05f, bowl.transform.position.z);
            Instantiate(SoupSpherePrefab, soupPosition, Quaternion.identity);
            Debug.Log("prefab instantiated");
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("soupParticles"))
        {
            startFilling = true;
            Debug.Log("soup in bowl");
        }
        else
        {
            Debug.Log("not soup particles...");
            startFilling = false;
        }
        if (collision.gameObject.tag == "bowl")
        {
            Physics.IgnoreCollision(collision.collider, GetComponent<Collider>());
        }
    }
}
