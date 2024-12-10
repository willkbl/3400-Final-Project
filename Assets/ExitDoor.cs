using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ExitDoor : MonoBehaviour
{
    public Canvas canvas;
    public Camera currentCamera;
    //public Light effectLight;

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
            Ray ray = currentCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                //Debug.Log(hit.collider);
                if (hit.collider == thisCollider)
                {
                    ObjectClicked();
                }
            }
        }
    }

    void ObjectClicked()
    {
        // this object was clicked - do something
        canvas.gameObject.SetActive(true);
        Debug.Log("clicked");
        //effectLight.gameObject.SetActive(false);
        //Debug.Log("Clicked");
    }

    
}
