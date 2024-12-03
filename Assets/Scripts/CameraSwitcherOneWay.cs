using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraSwitcherOneWay : MonoBehaviour
{

    public Transform player;

    public CinemachineVirtualCamera activeCam;

    public void Start()
    {
        activeCam = GetComponentInChildren<CinemachineVirtualCamera>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if(Mathf.Abs(Vector3.Angle(player.transform.forward, transform.forward)) < 90) {
                activeCam.Priority = 1;
            }
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            activeCam.Priority = 0;
        }
    }
}
