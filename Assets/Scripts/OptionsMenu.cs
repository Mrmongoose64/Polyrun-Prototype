using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsMenu : MonoBehaviour
{
    // Loads the main menu when the return button is pressed
    public void ReturnMainMenuButton()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
