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
        // for (int i = 0; i < toEnable.Count; ++i)
        // {
        // toEnable[i].SetActive(false);
        // }

        GameObject.Instantiate(uiHelpersToInstantiate);

        lp = FindObjectOfType<LaserPointer>();
        // if (!lp)
        //     {
        //     Debug.LogError("Debug UI requires use of a LaserPointer and will not function without it. Add one to your scene, or assign the UIHelpers prefab to the DebugUIBuilder in the inspector.");
        //     return;
        //     }
        // if (lp.laserBeamBehavior != laserBeamBehavior){
        lp.laserBeamBehavior = laserBeamBehavior;
        // }

        // if (!toEnable.Contains(lp.gameObject))
        // {
        // toEnable.Add(lp.gameObject);
        // }
        // if (GetComponent<OVRRaycaster>().pointer != lp.gameObject){
        GetComponent<OVRRaycaster>().pointer = lp.gameObject;
        // }
        
        // lp.gameObject.SetActive(false);
        // if (!lp.gameObject.activeSelf){
        lp.gameObject.SetActive(true);
        // }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public LaserPointer getLaser(){
        return lp;
    }
}
