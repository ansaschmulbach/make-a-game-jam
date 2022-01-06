using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JumpSceneManager : MonoBehaviour
{

    [SerializeField] private CinemachineVirtualCamera fullVCam;
    [SerializeField] private CinemachineVirtualCamera zoomVCam;
    [SerializeField] private string nextScene;
    
    void Start()
    {
        zoomVCam.Priority = 0;
        fullVCam.Priority = 1;
    }


    public void EndJump()
    {
        zoomVCam.Priority = 1;
        fullVCam.Priority = 0;
        StartCoroutine(EndScene());
    }

    IEnumerator EndScene()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(nextScene);
    }
    
}
