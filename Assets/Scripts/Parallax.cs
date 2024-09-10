using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Parallax scrolling effect for the background. Attach this script to the background object.
/// </summary>
/// <param name="cam">The camera object</param>
/// <param name="parallaxEffect">Weight to apply for the Parallax Effect</param>
public class Parallax : MonoBehaviour
{
    private float length, startpos, posY = 0f;
    public GameObject cam;
    public float parallaxEffect;

    void Start() {
        startpos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;

        // Log the background length for debugging
        Debug.Log("Background length: " + length);
    }

    void Update() {
        // Calculate camera's relative position
        float temp = cam.transform.position.x * (1 - parallaxEffect);
        float dist = cam.transform.position.x * parallaxEffect;

        // Move the background
        transform.position = new Vector3(startpos + dist, posY, transform.position.z);

        // Handle tiling: shift the background when the camera moves past the background's length
        if (temp > startpos + length) {
            startpos += length;
        }
        else if (temp < startpos - length) {
            startpos -= length;
        }
    }
}
