using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class TimerSystem : MonoBehaviour
{
    // The time to count down from
    public float maxTime;
    // The TextMeshPro object to output to
    public TextMeshProUGUI timerText;

    // Update is called once per frame
    void Update()
    {
        // Checks if the time is above 0
        if(maxTime > 0)
        {
            // Reduces the time by 1 second
            maxTime -= Time.deltaTime;
        }
        else
        {
            // Sets the timer to 0
            maxTime = 0;
        }

        VisualTimer(maxTime);
    }

    void VisualTimer(float timeToDisplay)
    {
        // Checks if the time is less than 0
        if (timeToDisplay < 0)
        {
            // Prevets the timer from going into negatives
            timeToDisplay = 0;
            // Loads the main menu if the timer hits 0
            SceneManager.LoadScene(0);
        }

        // Calculates the minutes
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        // Calculates the seconds
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        // Outputs them both to the TextMeshPro
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
