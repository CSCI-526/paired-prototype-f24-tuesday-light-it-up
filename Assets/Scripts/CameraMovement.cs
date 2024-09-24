using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraMovement : MonoBehaviour
{
    private Vector3 offset = new Vector3(0f, 0f, -10f);
    private float smoothTime = 0.05f;
    private Vector3 velocity = Vector3.zero;

    [SerializeField] private Transform target;
    private Camera mainCamera;

// Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        mainCamera.backgroundColor = Color.black;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (CompareColorWithRGB(mainCamera.backgroundColor, 100, 100, 100))
        {
            SceneManager.LoadScene("Level2");
        }

        Vector3 targetPosition = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }

    public bool CompareColorWithRGB(Color color, float r, float g, float b)
    {
        // Convert Unity color (0-1) to RGB (0-255) and compare
        return Mathf.RoundToInt(color.r * 255) == r &&
               Mathf.RoundToInt(color.g * 255) == g &&
               Mathf.RoundToInt(color.b * 255) == b;

    }

    public void AddColor(float r, float g, float b)
    {
        // Get the current background color in normalized values (0-1)
        Color currentColor = mainCamera.backgroundColor;

        // Convert current color from normalized to RGB (0-255)
        float currentR = currentColor.r * 255f;
        float currentG = currentColor.g * 255f;
        float currentB = currentColor.b * 255f;

        // Add the new RGB values to the current RGB values
        float newR = currentR + r;
        float newG = currentG + g;
        float newB = currentB + b;

        // Clamp the new values to ensure they are within the valid range (0-255)
        newR = Mathf.Clamp(newR, 0, 255);
        newG = Mathf.Clamp(newG, 0, 255);
        newB = Mathf.Clamp(newB, 0, 255);

        // Convert the result back to normalized values (0-1)
        float normalizedR = newR / 255f;
        float normalizedG = newG / 255f;
        float normalizedB = newB / 255f;

        // Set the new mixed color as the camera's background color
        mainCamera.backgroundColor = new Color(normalizedR, normalizedG, normalizedB);
    }

    public void MinusColor(float r, float g, float b)
    {
        // Get the current background color in normalized values (0-1)
        Color currentColor = mainCamera.backgroundColor;

        // Convert current color from normalized to RGB (0-255)
        float currentR = currentColor.r * 255f;
        float currentG = currentColor.g * 255f;
        float currentB = currentColor.b * 255f;

        // Subtract the new RGB values from the current RGB values
        float newR = currentR - r;
        float newG = currentG - g;
        float newB = currentB - b;

        // Clamp the new values to ensure they are within the valid range (0-255)
        newR = Mathf.Clamp(newR, 0, 255);
        newG = Mathf.Clamp(newG, 0, 255);
        newB = Mathf.Clamp(newB, 0, 255);

        // Convert the result back to normalized values (0-1)
        float normalizedR = newR / 255f;
        float normalizedG = newG / 255f;
        float normalizedB = newB / 255f;

        // Set the new mixed color as the camera's background color
        mainCamera.backgroundColor = new Color(normalizedR, normalizedG, normalizedB);
    }
}
