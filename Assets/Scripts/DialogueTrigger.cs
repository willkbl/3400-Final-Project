using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{

    public Canvas canvas;
    public Camera camera;
    
    Collider thisCollider;
    
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("Script runs");
        thisCollider = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        { // if left button pressed...
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log(hit.collider);
                if (hit.collider == thisCollider) {
                    ObjectClicked();
                }
            }
        }
    }

    void ObjectClicked(){
        // this object was clicked - do something
        canvas.gameObject.SetActive(true);
        Debug.Log("Clicked");
    }
 
}
