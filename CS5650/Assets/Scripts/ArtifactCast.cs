using UnityEngine;
using System.Collections;
using System.Diagnostics;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

// Show off all the Debug UI components.
public class ArtifactCast : OVRGrabber
{
    public LaserInit LaserInitObj;
    private LaserPointer laser;
    public NewUIBuilder NewUIBuilderObj;
    private NewUIBuilder instance;
    public string Title;
    public string Artist;
    public string Year;
    private LocomotionController lc;
    private bool inMenu = false;
    public int artID;
    private LocomotionTeleport TeleportController
    {
        get
        {
            return lc.GetComponent<LocomotionTeleport>(); 
        }
    }


	// protected override void Start() {
    void Start() {
        laser = LaserInitObj.getLaser();
        instance = NewUIBuilderObj.getInstance();
        lc = FindObjectOfType<LocomotionController>();

        instance.AddLabel(Title);
        instance.AddLabel(Artist);
        instance.AddLabel(Year);

        instance.PaintShow(artID);
        instance.Hide();
        inMenu = false;

        EventSystem eventSystem = FindObjectOfType<EventSystem>();
	}

    void Enter(){
        SceneManager.LoadScene(Title);
    }

    void Update()
    {
        if(OVRInput.GetDown(OVRInput.Button.Two) || OVRInput.GetDown(OVRInput.Button.Start))
        {
            if (inMenu) instance.Hide();
            else instance.PaintShow(artID);
            inMenu = !inMenu;
        }

        if (OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger) > 0.1f){
            RaycastHit rayHit; 
            Ray ray = new Ray(m_gripTransform.position, m_gripTransform.forward);
            // Ray ray = new Ray(GetComponent<OVRRaycaster>().pointer.transform.position, GetComponent<OVRRaycaster>().pointer.transform.forward);
            // Ray ray = new Ray(laser.gameObject.transform.position, laser.gameObject.transform.forward);
            if (Physics.Raycast(ray, out rayHit, Mathf.Infinity)) {
                Interact(rayHit);
            }
        }
    }

    private void Interact(RaycastHit hit){
        if (hit.collider.name.StartsWith("Paint")){
            if (inMenu) instance.Hide();
            else instance.PaintShow(artID);
            inMenu = !inMenu;
        }
        else{
            if (inMenu) instance.Hide();
            inMenu = false;
        }
    }
}
