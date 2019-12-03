using UnityEngine;
using System.Collections;
using System.Diagnostics;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

// Show off all the Debug UI components.
public class ArtworkCast : MonoBehaviour
{
    // public DebugUIBuilder DebugUIBuilderObj;
    // public string PaintingTitle;
    // public string Artist;
    // public string Year;
    // private LocomotionController lc;
    // private bool inMenu = false;
    // public int artID;
    // private LocomotionTeleport TeleportController
    // {
    //     get
    //     {
    //         return lc.GetComponent<LocomotionTeleport>(); 
    //     }
    // }

    // private DebugUIBuilder instance;

	// // protected override void Start() {
    // void Start() {
    //     instance = DebugUIBuilderObj.GetComponent<DebugUIBuilder>().getInstance();
    //     lc = FindObjectOfType<LocomotionController>();

    //     instance.AddLabel(PaintingTitle, artID);
    //     instance.AddLabel(Artist, artID);
    //     instance.AddLabel(Year, artID);
    //     instance.AddButton("Close", Close, artID);
    //     instance.AddButton("Enter", Enter, artID);

    //     instance.Show();

    //     EventSystem eventSystem = FindObjectOfType<EventSystem>();
	// }

    // void Enter(){
    //     SceneManager.LoadScene(PaintingTitle);
    // }

    // void Close()
    // {
    //     if (inMenu) instance.Hide();
    //     inMenu = false;
    // }

    // void Update()
    // {
    //     // if(OVRInput.GetDown(OVRInput.Button.Two) || OVRInput.GetDown(OVRInput.Button.Start))
    //     // {
    //     //     if (inMenu) DebugUIBuilder.instance.Hide();
    //     //     else DebugUIBuilder.instance.Show();
    //     //     inMenu = !inMenu;
    //     // }

    //     // if (OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger) > 0.1f){
    //     //     RaycastHit rayHit; 
    //     //     Ray ray = new Ray(m_gripTransform.position, m_gripTransform.forward);
    //     //     if (Physics.Raycast(ray, out rayHit, Mathf.Infinity)) {
    //     //         Interact(rayHit);
    //     //     }
    //     // }
    // }

    // private void Interact(RaycastHit hit){
    //     if (hit.collider.name.StartsWith("Paint")){
    //         if (inMenu) instance.Hide();
    //         else instance.Show();
    //         inMenu = !inMenu;
    //     }
    //     else{
    //         if (inMenu) instance.Hide();
    //         inMenu = false;
    //     }
    // }
}
