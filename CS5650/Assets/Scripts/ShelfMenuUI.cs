using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShelfMenuUI : MonoBehaviour
{
    bool inMenu;
    private Text sliderText;

	void Start ()
    {
        MenuUIBuilder.instance.AddLabel("Game Menu");
        MenuUIBuilder.instance.AddButton("Return to Lobby", GoToLobby);
        MenuUIBuilder.instance.AddButton("Go to Debug UI", GoToDebugUI);
        
        MenuUIBuilder.instance.Show();
        inMenu = true;
	}

    void Update()
    {
        if(OVRInput.GetDown(OVRInput.Button.Two) || OVRInput.GetDown(OVRInput.Button.Start))
        {
            if (inMenu) MenuUIBuilder.instance.Hide();
            else MenuUIBuilder.instance.Show();
            inMenu = !inMenu;
        }
    }

    void GoToLobby() {
        Debug.Log("in lieu of Lobby");
        // SceneManager.LoadScene("Lobby");
    }

    // void GoToDali() {
    //     SceneManager.LoadScene("MemoryScene");
    // }

    // void GoToWarhol() {
    //     SceneManager.LoadScene("ShelfScene");
    // }

    void GoToDebugUI() {
        SceneManager.LoadScene("DebugUI");
    }
}
