using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine2 : MonoBehaviour
{
    // Reference to the Main Camera
    private Camera mainCamera;
    private CameraMovement cm;

    public bool touched = false;

    // Start is called before the first frame update
    void Start()
    {
        // Get reference to the main camera at the start
        mainCamera = Camera.main;
        cm = FindObjectOfType<CameraMovement>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (touched)
        {
            touched = false;
            cm.MinusColor(0, 0, 255);
        }
        else
        {
            touched = true;
            cm.AddColor(0, 0, 255);
            SceneManager.LoadScene("Level2");
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
