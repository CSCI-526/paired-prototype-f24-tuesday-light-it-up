using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    // Reference to the Main Camera
    private Camera mainCamera;
    private CameraMovement cm;
    
    public bool canDoubleJump = false;

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
        if (canDoubleJump)
        {
            canDoubleJump = false;
            cm.MinusColor(100, 0, 0);
        }
        else
        {
            canDoubleJump = true;
            cm.AddColor(100, 0, 0);
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
