using UnityEngine;
using System.Collections;
using System.Diagnostics;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;
using UnityEngine.EventSystems;
using UnityEngine.Events;

// Show off all the Debug UI components.
public class SculptSlider : MonoBehaviour
{
    public string Title;
    public string Artist;
    public string Year;
    private LocomotionController lc;
    private bool inMenu = false;
    private Text sliderText;
    private Text rotText;
    // LaserPointer lp;
    // public LaserPointer.LaserBeamBehavior laserBeamBehavior;
    private LocomotionTeleport TeleportController
    {
        get
        {
            return lc.GetComponent<LocomotionTeleport>(); 
        }
    }
    public Vector3 origScale;
    public int sculptID;
    private float prevRot = 0;

    // void Awake(){
    //     lp = FindObjectOfType<LaserPointer>();
    //     lp.laserBeamBehavior = laserBeamBehavior;
    //     GetComponent<OVRRaycaster>().pointer = lp.gameObject;
    //     lp.gameObject.SetActive(true);
    // }

	// protected override void Start() {
    void Start() {
        lc = FindObjectOfType<LocomotionController>();
        DebugUIBuilder.instance.AddLabel(Title, sculptID);
        DebugUIBuilder.instance.AddLabel(Artist, sculptID);
        DebugUIBuilder.instance.AddLabel(Year, sculptID);

        var sliderPrefab = DebugUIBuilder.instance.AddSlider("Scale", 1f, 2.0f, SliderPressed, false, sculptID);
        var sliderRot = DebugUIBuilder.instance.AddSlider("Rotation", 0f, 360f, SliderRotate, true, sculptID);
        var textElementsInSlider = sliderPrefab.GetComponentsInChildren<Text>();
        var textElementsInRotSlider = sliderRot.GetComponentsInChildren<Text>();
        textElementsInSlider[0].text = "Scale:";
        textElementsInRotSlider[0].text = "Rotation:";
        sliderText = textElementsInSlider[1];
        sliderText.text = sliderRot.GetComponentInChildren<Slider>().value.ToString();
        rotText = textElementsInRotSlider[1];
        rotText.text = sliderRot.GetComponentInChildren<Slider>().value.ToString();
        DebugUIBuilder.instance.SculptShow(sculptID);
        DebugUIBuilder.instance.Hide();
        inMenu = false;

        origScale = transform.localScale;

        EventSystem eventSystem = FindObjectOfType<EventSystem>();
	}

    public void SliderPressed(float f)
    {
        sliderText.text = f.ToString();
        transform.localScale = origScale * f;
    }

    public void SliderRotate(float f)
    {
        rotText.text = f.ToString();
        transform.Rotate(0, 0, prevRot - f, Space.Self);
        prevRot = f;
    }

    void Update()
    {
        if(OVRInput.GetDown(OVRInput.Button.Two) || OVRInput.GetDown(OVRInput.Button.Start))
        {
            if (inMenu) DebugUIBuilder.instance.Hide();
            else DebugUIBuilder.instance.SculptShow(sculptID);
            inMenu = !inMenu;
        }

        if (OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger) > 0.1f){
            RaycastHit rayHit; 
            // Ray ray = new Ray(m_gripTransform.position, m_gripTransform.forward);
            Ray ray = new Ray(GetComponent<OVRRaycaster>().pointer.transform.position, GetComponent<OVRRaycaster>().pointer.transform.forward);
            if (Physics.Raycast(ray, out rayHit, Mathf.Infinity)) {
                Interact(rayHit);
            }
        }
    }

    private void Interact(RaycastHit hit){
        if (hit.collider.name.StartsWith("Sculpt")){
            if (inMenu) DebugUIBuilder.instance.Hide();
            else DebugUIBuilder.instance.SculptShow(sculptID);
            inMenu = !inMenu;
        }
        else{
            if (inMenu) DebugUIBuilder.instance.Hide();
            inMenu = false;
        }
    }
}
