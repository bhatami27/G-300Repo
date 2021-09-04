using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingScript : MonoBehaviour
{
    private float lastY;
    public float FallingThreshold = -0.01f;
    //[HideInInspector]
    public bool Falling = false;

    AudioSource falling;

    // Start is called before the first frame update
    void Start()
    {
        lastY = transform.position.y;
        falling = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        float distancePerSecondSinceLastFrame = (transform.position.y - lastY) * Time.deltaTime;
        lastY = transform.position.y;
        if (distancePerSecondSinceLastFrame < FallingThreshold)
        {
            Falling = true;
            
        }
        else
        {
            Falling = false;
        }

        if (Falling == true)
        {
            falling.Play();
        }
        if (Falling == false)
        {
            falling.Stop();
        }

    }
}
