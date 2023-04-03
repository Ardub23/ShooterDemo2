using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static UnityEngine.UIElements.UxmlAttributeDescription;

public class CrosshairBehavior : MonoBehaviour
{
    // Distance from screen edge (in pixels) at which camera scrolls
    public float screenEdgeSize = 40f;

    public float cameraScrollSpeed = 2f;

    public int shots = 0;
    public int hits = 0;

    public AudioSource shootSound;
    public AudioSource hitSound;

    // Update is called once per frame
    void Update()
    {
        // Move crosshair to mouse position
        // Use a Vector2 to prevent the z-coord from going behind the camera
        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = pos;

        // Near the edge of the screen, move the camera
        ScrollCamera();

        if (Input.GetMouseButtonDown(0)) // left button
        {
            shots++;
            shootSound.Play();
            // The targets determine whether they've been hit
        }
    }

    public void Hit()
    {
        hits++;
        hitSound.Play();
    }

    private void ScrollCamera()
    {
        if (Input.mousePosition.y < screenEdgeSize)
        {
            Camera.main.transform.position += new Vector3(0, -Time.deltaTime * cameraScrollSpeed);
        }
        else if (Input.mousePosition.y > (Camera.main.pixelHeight - screenEdgeSize))
        {
            Camera.main.transform.position += new Vector3(0, Time.deltaTime * cameraScrollSpeed);
        }

        if (Input.mousePosition.x < screenEdgeSize)
        {
            Camera.main.transform.position += new Vector3(-Time.deltaTime * cameraScrollSpeed, 0);
        }
        else if (Input.mousePosition.x > (Camera.main.pixelWidth - screenEdgeSize))
        {
            Camera.main.transform.position += new Vector3(Time.deltaTime * cameraScrollSpeed, 0);
        }
    }
}
