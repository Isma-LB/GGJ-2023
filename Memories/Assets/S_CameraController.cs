using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class S_CameraController : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private CinemachineVirtualCamera TopCamera;
    [SerializeField] private CinemachineVirtualCamera OnEnterCamera;
    [SerializeField] private CinemachineVirtualCamera WinCamera;

  
    void Start()
    {
        TopCamera.gameObject.SetActive(true);
        OnEnterCamera.gameObject.SetActive(false);
        WinCamera.gameObject.SetActive(false);
    }


    public void winCamera()
    {
        TopCamera.gameObject.SetActive(false);
        OnEnterCamera.gameObject.SetActive(false);
        WinCamera.gameObject.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
