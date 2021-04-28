using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioStop : MonoBehaviour
{
    private AudioSource AS;
    private bool isPressed;

    // Start is called before the first frame update
    void Start()
    {
        AS = GetComponent<AudioSource>();
        isPressed = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Pressed()
    {
        if (!isPressed)
        {
            Stop();
        }
        else
        {
            Resume();
        }
    }

    public void Stop()
    {
        isPressed = true;
        AS.Stop();
        AS.enabled = false;
    }

    public void Resume()
    {
        isPressed = false;
        AS.enabled = true;
        AS.Play();
    }
}