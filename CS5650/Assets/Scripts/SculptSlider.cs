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
    public LaserInit LaserInitObj;
    private LaserPointer laser;
    public NewUIBuilder NewUIBuilderObj;
    private NewUIBuilder instance;
    public string Title;
    public string Artist;
    public string Year;
    private LocomotionController lc;
    private bool inMenu = false;
    private Text sliderText;
    private Text rotText;
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

        var sliderPrefab = instance.AddSlider("Scale", 1f, 2.0f, SliderPressed, false);
        var sliderRot = instance.AddSlider("Rotation", 0f, 360f, SliderRotate, true);
        var textElementsInSlider = sliderPrefab.GetComponentsInChildren<Text>();
        var textElementsInRotSlider = sliderRot.GetComponentsInChildren<Text>();
        textElementsInSlider[0].text = "Scale:";
        textElementsInRotSlider[0].text = "Rotation:";
        sliderText = textElementsInSlider[1];
        sliderText.text = sliderRot.GetComponentInChildren<Slider>().value.ToString();
        rotText = textElementsInRotSlider[1];
        rotText.text = sliderRot.GetComponentInChildren<Slider>().value.ToString();
        instance.SculptShow(sculptID);
        instance.Hide();
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
        transform.Rotate(0, prevRot - f, 0, Space.Self);
        prevRot = f;
    }

    void Update()
    {
        if(OVRInput.GetDown(OVRInput.Button.Two) || OVRInput.GetDown(OVRInput.Button.Start))
        {
            if (inMenu) instance.Hide();
            else instance.SculptShow(sculptID);
            inMenu = !inMenu;
        }
    }
}
