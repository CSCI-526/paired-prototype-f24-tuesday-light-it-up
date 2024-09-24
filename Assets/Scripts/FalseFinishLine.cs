using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FalseFinishLine : MonoBehaviour
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
            cm.MinusColor(50, 0, 50);
        }
        else
        {
            touched = true;
            cm.AddColor(50, 0, 50);
        }

        // }
    }
}
