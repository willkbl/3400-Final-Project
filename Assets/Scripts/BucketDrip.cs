using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BucketDrip : MonoBehaviour
{

    AudioSource dropletSound;

    // Start is called before the first frame update
    void Start()
    {
        dropletSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnParticleCollision(GameObject other)
    {
        //Debug.Log("Collision!");
        if (other.CompareTag("WaterDroplet"))
        {
            dropletSound.pitch = UnityEngine.Random.Range(0.9f, 1.1f);
            dropletSound.Play();
        }
    }
}
