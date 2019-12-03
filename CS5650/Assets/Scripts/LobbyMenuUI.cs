using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LobbyMenuUI : MonoBehaviour
{
    bool inMenu;
    private Text sliderText;

	void Start ()
    {
        MenuUIBuilder.instance.AddLabel("Game Menu");
        MenuUIBuilder.instance.AddButton("Reload Scene", GoToLobby);
        // MenuUIBuilder.instance.AddButton("Enter Campbell's Soup Cans", GoToWarhol);    
        // MenuUIBuilder.instance.AddButton("Enter the Persistence of Memory", GoToDali);            
        // MenuUIBuilder.instance.Show();
        inMenu = false;
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
        SceneManager.LoadScene("Lobby");
    }

    void GoToDali() {
        SceneManager.LoadScene("The Persistence of Memory");
    }

    void GoToWarhol() {
        SceneManager.LoadScene("Campbell's Soup Cans");
    }

}
