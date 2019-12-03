using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserInit : MonoBehaviour
{
    // private List<GameObject> toEnable;
    [SerializeField]
    private GameObject uiHelpersToInstantiate;
    LaserPointer lp;
    LineRenderer lr;
    

    public LaserPointer.LaserBeamBehavior laserBeamBehavior;

    void Awake(){
        GameObject.Instantiate(uiHelpersToInstantiate);
        lp = FindObjectOfType<LaserPointer>();
        lp.laserBeamBehavior = laserBeamBehavior;
        GetComponent<OVRRaycaster>().pointer = lp.gameObject;
        lp.gameObject.SetActive(true);
    }

    public LaserPointer getLaser(){
        return lp;
    }
}
