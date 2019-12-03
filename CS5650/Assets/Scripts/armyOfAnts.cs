using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus.Avatar;

public class armyOfAnts : MonoBehaviour
{
    //if the clock is grabbed, instantiate a bunch of smolAnts
    OVRGrabbable grabState;
    public GameObject smolAnt;
    //public GameObject ClockAnts;
    public GameObject Platform2;
    public GameObject giAnt;
    bool activated;
    // Start is called before the first frame update
    void Start()
    {
        grabState = GetComponent<OVRGrabbable>();
    }

    // Update is called once per frame
    void Update()
    {
        if (grabState.isGrabbed == true)
        {
            Instantiate(smolAnt, new Vector3(transform.position.x, transform.position.y + 0.05f, transform.position.z), Quaternion.identity);
        }

        if (grabState.isGrabbed == true && (OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger) > 0.5f))
        {
            activated = true;
        }

        if (activated)
        {
            Instantiate(giAnt, Platform2.transform.position, Quaternion.identity);
            activated = false;
        }
    }
}
