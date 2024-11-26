using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{

    public Canvas canvas;
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Script runs");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.S))
        {
            Debug.Log("S key pressed");
        }
    }

    void OnMouseDown(){
        // this object was clicked - do something
        canvas.gameObject.SetActive(true);
        Debug.Log("Clicked");
    }
 
}
