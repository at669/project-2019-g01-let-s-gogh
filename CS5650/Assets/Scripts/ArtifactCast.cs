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

    void Start() {
        laser = LaserInitObj.getLaser();
        instance = NewUIBuilderObj.getInstance();
        lc = FindObjectOfType<LocomotionController>();

        if (Title.Length > 0) {
            instance.AddLabel(Title);
        }
        if (Artist.Length > 0) {
            instance.AddLabel(Artist);
        }
        if (Year.Length > 0) {
            instance.AddLabel(Year);
        }

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
    }
}
