using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPoint : MonoBehaviour
{
    public Vector3 restartingVelocity = new Vector3(-1, -1, 0);
    public int restartingCamera;
    public GameObject ball;
    public GameObject _C;
    Ball ballScript;
    bool green = false;
    void Start()
    {
        ballScript = ball.GetComponent<Ball>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!green && other.CompareTag("Ball"))
        {
            ballScript.restartingVelocity = restartingVelocity.normalized;
            ballScript.restartingPositon = gameObject.transform.position;
            ballScript.restartingCamera = restartingCamera;
            green = true;
            _C.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
            _C.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.green);
        }
    }
}
