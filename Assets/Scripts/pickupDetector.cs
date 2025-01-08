using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; // Enables the editing of TextMeshPro objects

public class pickupDetector : MonoBehaviour
{
    // The script uses the player's Rididbody2D for collision with the pickups
    private Rigidbody2D rb2d;
    // Links the editable TextMeshPros to the script
    // SerializeField keeps the variables private whilst still making them visible in the editor
    [SerializeField] private TextMeshProUGUI coinCounter, emeraldCounter, rubyCounter;
    // The three variables used to keep track of the pickup counts
    private int coinCount, emeraldCount, rubyCount;
    // Variable to store the current scene's index number
    public int currentSceneIndex;

    // Start is called before the first frame update
    void Start()
    {
        // Retrieves the index number of the current scene
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        
        // Retrieves a reference of the Rigidbody2D
        rb2d = GetComponent<Rigidbody2D>();
        // Sets the pickup counts to zero
        coinCount = 0;
        emeraldCount = 0;
        rubyCount = 0;
    }

    // Update is called once per frame
    void Update()
    {        
        // Edits the TextMeshPros with the updated pickup counts
        coinCounter.text = "Coins Collected: " + coinCount + "/4";
        emeraldCounter.text = "Emeralds Collected: " + emeraldCount + "/4";
        rubyCounter.text = "Rubies Collected: " + rubyCount + "/4";

        // Checks if all 12 pickups have been collected
        if ((coinCount + emeraldCount + rubyCount) == 12)
        {
            // Loads the next scene by incrementing the scene index by 1
            SceneManager.LoadScene(currentSceneIndex + 1);
        }
    }

    // Detects if the player touches a pickup's trigger area
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Increases the count and destroys the specific instance of each pickup when collected
        if (collision.GetComponent<Coin>())
        {
            coinCount++;
            Destroy(collision.gameObject);
        }
        else if (collision.GetComponent<Emerald>())
        {
            emeraldCount++;
            Destroy(collision.gameObject);
        }
        else if (collision.GetComponent<Ruby>())
        {
            rubyCount++;
            Destroy(collision.gameObject);
        }
    }
}
