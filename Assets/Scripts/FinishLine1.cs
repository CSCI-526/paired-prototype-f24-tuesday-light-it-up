using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine1 : MonoBehaviour
{
    private Camera mainCamera;
    private CameraMovement cm;
    public bool canAttack = false;
    
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
        if (canAttack)
        {
            canAttack = false;
            cm.MinusColor(0, 255, 0);
        }
        else
        {
            canAttack = true;
            cm.AddColor(0, 255, 0);

        }

        // }
    }



}
