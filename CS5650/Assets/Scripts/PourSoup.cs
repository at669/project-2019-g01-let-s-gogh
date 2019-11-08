using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PourSoup : MonoBehaviour
{
    public GameObject soupInCan;
    public GameObject soup;
    private IEnumerator coroutine;
    //GameObject pour;
    bool pouring = true;
    // Start is called before the first frame update
    void Start()
    {
        soup.SetActive(false);
        coroutine = PourDaSoup(0.3f);
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
                pouring = false;
            }
            else
            {
                pouring = true;
                soup.SetActive(false);
            }
        }
        if (!pouring)
        {
            StartCoroutine(coroutine);
        }
    }

    private IEnumerator PourDaSoup(float waitTime)
    {
        soup.SetActive(true);
        soup.transform.position = new Vector3(transform.position.x, transform.position.y + 0.1f, transform.position.z);
        soup.transform.rotation = transform.rotation; 
        pouring = true;
        yield return new WaitForSeconds(waitTime);
    }
}
