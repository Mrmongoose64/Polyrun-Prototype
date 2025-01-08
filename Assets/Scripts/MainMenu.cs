using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Loads the first level when the play button is pressed
    public void PlayButton()
    {
        SceneManager.LoadScene(2);
    }

    // Loads the options menu when the option button is pressed
    public void OptionsButton()
    {
        SceneManager.LoadScene(1);
    }

    // Quits the game when using a build
    // Logs a message to the console when testing in unity
    public void QuitButton()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
