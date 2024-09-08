using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{

    private float length, startpos, posY=2.5f;
    public GameObject cam;
    public float parallaxEffect;

    void Start() {
        startpos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update() {
        float temp = cam.transform.position.x * (1 - parallaxEffect);
        float dist = cam.transform.position.x * parallaxEffect;
//        transform.position = new Vector3(startpos + dist, transform.position.y, transform.position.z);
        transform.position = new Vector3(startpos + dist, posY, transform.position.z);
        if (temp > startpos + length) {
            startpos += length;
        }
        else if (temp < startpos - length) {
            startpos -= length;
        }
    }

}