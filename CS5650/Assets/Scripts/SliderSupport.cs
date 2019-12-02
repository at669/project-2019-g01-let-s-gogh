// #define DEBUG_LOCOMOTION_PANEL

using UnityEngine;
using System.Collections;
using System.Diagnostics;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class SliderSupport : MonoBehaviour
{
    private LocomotionController lc;
    private bool inMenu = false;
    private Text sliderText;
    private LocomotionTeleport TeleportController
    {
        get
        {
            return lc.GetComponent<LocomotionTeleport>(); 
        }
    }

    public void Start()
    {
        lc = FindObjectOfType<LocomotionController>();
        var sliderPrefab = DebugUIBuilder.instance.AddSlider("Slider", 1.0f, 10.0f, SliderPressed, true);
        var textElementsInSlider = sliderPrefab.GetComponentsInChildren<Text>();
        sliderText = textElementsInSlider[1];
        sliderText.text = sliderPrefab.GetComponentInChildren<Slider>().value.ToString();

        // This is just a quick hack-in, need a prefab-based way of setting this up easily.
        EventSystem eventSystem = FindObjectOfType<EventSystem>();
        if (eventSystem == null)
        {
            Debug.LogError("Need EventSystem");
        }

        // SAMPLE-ONLY HACK:
        // Due to restrictions on how Unity project settings work, we just hackily set up default
        // to ignore the water layer here. In your own project, you should set up your collision
        // layers properly through the Unity editor.
        Physics.IgnoreLayerCollision(0, 4);
    }

    public void Update()
    {
        if(OVRInput.GetDown(OVRInput.Button.Two) || OVRInput.GetDown(OVRInput.Button.Start))
        {
            if (inMenu) DebugUIBuilder.instance.Hide();
            else DebugUIBuilder.instance.Show();
            inMenu = !inMenu;
        }
    }

    [Conditional("DEBUG_LOCOMOTION_PANEL")]
    static void Log(string msg)
    {
        Debug.Log(msg);
    }

    // /// <summary>
    // /// This method will ensure only one specific type TActivate in a given group of components derived from the same TCategory type is enabled.
    // /// This is used by the sample support code to select between different targeting, input, aim, and other handlers.
    // /// </summary>
    // /// <typeparam name="TCategory"></typeparam>
    // /// <typeparam name="TActivate"></typeparam>
    // /// <param name="target"></param>
    // public static TActivate ActivateCategory<TCategory, TActivate>(GameObject target) where TCategory : MonoBehaviour where TActivate : MonoBehaviour
    // {
    //     var components = target.GetComponents<TCategory>();
    //     Log("Activate " + typeof(TActivate) + " derived from " + typeof(TCategory) + "[" + components.Length + "]");
    //     TActivate result = null;
    //     for (int i = 0; i < components.Length; i++)
    //     {
    //         var c = (MonoBehaviour)components[i];
    //         var active = c.GetType() == typeof(TActivate);
    //         Log(c.GetType() + " is " + typeof(TActivate) + " = " + active);
    //         if (active)
    //         {
    //             result = (TActivate)c;
    //         }
    //         if (c.enabled != active)
    //         {
    //             c.enabled = active;
    //         }
    //     }
    //     return result;
    // }

    // /// <summary>
    // /// This generic method is used for activating a specific set of components in the LocomotionController. This is just one way 
    // /// to achieve the goal of enabling one component of each category (input, aim, target, orientation and transition) that
    // /// the teleport system requires.
    // /// </summary>
    // /// <typeparam name="TInput"></typeparam>
    // /// <typeparam name="TAim"></typeparam>
    // /// <typeparam name="TTarget"></typeparam>
    // /// <typeparam name="TOrientation"></typeparam>
    // /// <typeparam name="TTransition"></typeparam>
    // protected void ActivateHandlers<TInput, TAim, TTarget, TOrientation, TTransition>()
    //     where TInput : TeleportInputHandler
    //     where TAim : TeleportAimHandler
    //     where TTarget : TeleportTargetHandler
    //     where TOrientation : TeleportOrientationHandler
    //     where TTransition : TeleportTransition
    // {
    //     ActivateInput<TInput>();
    //     ActivateAim<TAim>();
    //     ActivateTarget<TTarget>();
    //     ActivateOrientation<TOrientation>();
    //     ActivateTransition<TTransition>();
    // }

    // protected void ActivateInput<TActivate>() where TActivate : TeleportInputHandler
    // {
    //     ActivateCategory<TeleportInputHandler, TActivate>();
    // }

    // protected void ActivateAim<TActivate>() where TActivate : TeleportAimHandler
    // {
    //     ActivateCategory<TeleportAimHandler, TActivate>();
    // }

    // protected void ActivateTarget<TActivate>() where TActivate : TeleportTargetHandler
    // {
    //     ActivateCategory<TeleportTargetHandler, TActivate>();
    // }

    // protected void ActivateOrientation<TActivate>() where TActivate : TeleportOrientationHandler
    // {
    //     ActivateCategory<TeleportOrientationHandler, TActivate>();
    // }

    // protected void ActivateTransition<TActivate>() where TActivate : TeleportTransition
    // {
    //     ActivateCategory<TeleportTransition, TActivate>();
    // }

    // protected TActivate ActivateCategory<TCategory, TActivate>() where TCategory : MonoBehaviour where TActivate : MonoBehaviour
    // {
    //     return ActivateCategory<TCategory, TActivate>(lc.gameObject);
    // }

    // protected GameObject AddInstance(GameObject template, string label)
    // {
    //     var go = Instantiate(template);
    //     go.transform.SetParent(transform, false);
    //     go.name = label;
    //     return go;
    // }

    public void SliderPressed(float f)
    {
        Debug.Log("Slider: " + f);
        sliderText.text = f.ToString();
    }
}
