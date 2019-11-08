using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OculusSampleFramework
{
public class ScalableObject : MonoBehaviour
{
    public GameObject Top;
    public GameObject Bottom;
    private float origDist;
    private Vector3 origScale;
    private bool prevGrabbed;
    private bool currentlyGrabbed;
    private Vector3 tmpTopPos;
    private Vector3 tmpBotPos;

    // Start is called before the first frame update
    void Start()
    {
        origDist = Vector3.Distance(Top.transform.position, Bottom.transform.position);
        origScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (Top.GetComponent<OVRGrabbable>().isGrabbed && Bottom.GetComponent<OVRGrabbable>().isGrabbed){
            currentlyGrabbed = true;
            float newDist = Vector3.Distance(Top.transform.position, Bottom.transform.position);
            if (newDist - origDist > 0.0001f){ // check if stretched
                float ratio = newDist / origDist;
                Vector3 newScale = ratio * origScale;
                transform.localScale = newScale;

                // transform.position = (0.5f * (Top.transform.position + Bottom.transform.position));

                origScale = newScale;
                origDist = Vector3.Distance(Top.transform.position, Bottom.transform.position);
                // tmpTopPos = Top.transform.position;
                // tmpBotPos = Bottom.transform.position;
            }
        }
        else{
            currentlyGrabbed = false;
        }
        if (!currentlyGrabbed && prevGrabbed){ // just let go of both
            // Top.transform.position = tmpTopPos;
            // Bottom.transform.position = tmpBotPos;
            // origDist = Vector3.Distance(Top.transform.position, Bottom.transform.position);
        }
        prevGrabbed = currentlyGrabbed;
        
    }
}
}