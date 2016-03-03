using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

    public GameObject quitMenu;

	// Use this for initialization
	void Start ()
    {
        quitMenu.SetActive(false);
    }
	
	// Update is called once per frame
	void Update ()
    {
	    if(Input.GetKeyDown(KeyCode.Escape))
        {
            // Set everything menus to false to go back to main menu
            quitMenu.SetActive(false);
        }
	}

    public void SoloPlay()
    {

    }

    public void EnableQuitMenu()
    {
        quitMenu.SetActive(true);
    }

    public void ConfirmQuit()
    {
        Application.Quit();
    }

    public void DenyQuit()
    {
        quitMenu.SetActive(false);
    }
}
