using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    // Sets the movement speed of the player
    public float speed;
    // The script uses the player's Rididbody2D for movement
    private Rigidbody2D rb2d;

    // Update is called once per frame
    void Update()
    {
        // Retrieves a reference of the Rigidbody2D
        rb2d = GetComponent<Rigidbody2D>();

        // Sets the inputs as horizontal and vertical
        // Defaults to the arrow keys and WASD keys
        float horInput = Input.GetAxis("Horizontal");
        float verInput = Input.GetAxis("Vertical");

        // Creates a new Vector3 that links the inputs to movement
        Vector3 move = new Vector3(horInput, verInput, 0);

        // Checks if inputs are being made
        if (horInput != 0 || verInput != 0)
        {
            // Only runs when the player's magnitude goes over the maximum
            if (move.magnitude > 1)
            {
                // Keeps the magnitude at a maximum value of 1
                move = move.normalized;
            }
            // Moves the player with physics using the inputs and speed
            rb2d.velocity = move * speed;
            
            // Logs the player's magnitude to the console (only visible in Unity)
            Debug.Log(move.magnitude);
        }
        else
        {
            // Halts the player if no inputs are being made
            rb2d.velocity = move * 0;
        }
    }
}
