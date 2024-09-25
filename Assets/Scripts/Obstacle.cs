using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacle : MonoBehaviour
{
    private CameraMovement cm;
    private Camera mainCamera;
    private SpriteRenderer spriteRenderer;
    private Color obColor;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        cm = FindObjectOfType<CameraMovement>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        obColor = spriteRenderer.color;
    }

    // Update is called once per frame
    void Update()
    {
        if (mainCamera.backgroundColor.Equals(obColor))
        {
            spriteRenderer.enabled = false;
            gameObject.layer = LayerMask.NameToLayer("IgnoreObstacle");
        }
        else
        {
            spriteRenderer.enabled = true;
            gameObject.layer = LayerMask.NameToLayer("Wall");
        }
    }
}
