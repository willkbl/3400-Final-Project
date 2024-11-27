using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;


public class EnableOnStart : MonoBehaviour
{

    public PostProcessLayer layer;

    // Start is called before the first frame update
    void Start()
    {
        layer.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
