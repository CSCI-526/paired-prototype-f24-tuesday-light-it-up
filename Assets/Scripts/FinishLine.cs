using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    // Reference to the Main Camera
    private Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        // Get reference to the main camera at the start
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the collision is with the player
        //if (collision.gameObject.CompareTag("Player"))
        //{
        // Change the background color to red
        if (mainCamera.backgroundColor == Color.red)
        {
            mainCamera.backgroundColor = Color.black;
        }
        else
        {
            mainCamera.backgroundColor = Color.red;
        }
           
       // }
    }

    /*
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("Level2");
        }
    }
    */
}
