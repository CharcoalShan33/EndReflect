using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.SceneManagement;
using Scene = UnityEngine.SceneManagement.Scene;


public class CameraController : MonoBehaviour
{
    PlayerController target;
    CinemachineVirtualCamera vCam;
    // Start is called before the first frame update
    void Start()
    {
        target = FindObjectOfType<PlayerController>();
        vCam = GetComponent<CinemachineVirtualCamera>();
        vCam.Follow = target.transform;
    }

    // Update is called once per frame
    public void OnSceneLoaded(Scene scene, LoadSceneMode mode) 
    {
        if(scene.name == "BattleScene")
        {
            vCam.enabled = false;
            target.enabled = false;

        }
        else
        {
           target.enabled = true;
            vCam.enabled = true;
        }
    }   

    public void StartCamera()
    {
        vCam.enabled = true;
        vCam.Follow = target.transform;
    }
}
