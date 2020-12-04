using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChanger : MonoBehaviour
{
    public int CameraToChange;
    public GameObject LevelCamera;
    private LevelCamera cam;

    void Start()
    {
        cam = LevelCamera.GetComponent<LevelCamera>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            cam.setActualCamera(CameraToChange);
        }
    }
}
