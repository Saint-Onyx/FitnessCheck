using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private float minZoom = 25f;
    private float maxZoom = 60f;
    private float currentZoom;
    private float sensitivity = 50f;
    
    /// <summary>
    /// Enables camera movement. Independent from Time.deltaTime to allow rotation while paused
    /// </summary>
    void Update()
    {
        if (Input.GetKey("left"))
        {
            transform.Rotate(0, 100 * 0.02f, 0);
        }
        if (Input.GetKey("right"))
        {
            transform.Rotate(0, -100 * 0.02f, 0);
        }

        currentZoom = Camera.main.fieldOfView;
        currentZoom -= Input.GetAxis("Mouse ScrollWheel") * sensitivity;
        currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);
        Camera.main.fieldOfView = currentZoom;

    }
}
