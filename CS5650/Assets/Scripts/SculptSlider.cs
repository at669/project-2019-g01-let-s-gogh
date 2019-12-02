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
    // bool inMenu;
    public Vector3 origScale;
    public int sculptID = 0;
    private float prevRot = 0;

	void Start ()
    {
        lc = FindObjectOfType<LocomotionController>();
        var sliderPrefab = DebugUIBuilder.instance.AddSlider("Scale", 1f, 2.0f, SliderPressed, false, sculptID);
        var sliderRot = DebugUIBuilder.instance.AddSlider("Rotation", 0f, 360f, SliderRotate, true, sculptID);
        var textElementsInSlider = sliderPrefab.GetComponentsInChildren<Text>();
        var textElementsInRotSlider = sliderRot.GetComponentsInChildren<Text>();
        sliderText = textElementsInSlider[1];
        sliderText.text = sliderRot.GetComponentInChildren<Slider>().value.ToString();
        rotText = textElementsInRotSlider[1];
        rotText.text = sliderRot.GetComponentInChildren<Slider>().value.ToString();
        DebugUIBuilder.instance.Show();
        inMenu = true;

        origScale = transform.localScale;

        EventSystem eventSystem = FindObjectOfType<EventSystem>();
        if (eventSystem == null)
        {
            Debug.LogError("Need EventSystem");
        }
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
            else DebugUIBuilder.instance.Show();
            inMenu = !inMenu;
        }
    }
}
