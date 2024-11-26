using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;


public class CameraController : MonoBehaviour
{
    PlayerController playerTarget;
    CinemachineVirtualCamera vCam;
    // Start is called before the first frame update
    void Start()
    {
        playerTarget = GameObject.FindObjectOfType<PlayerController>();
        vCam = GetComponent<CinemachineVirtualCamera>();
        vCam.Follow = playerTarget.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
