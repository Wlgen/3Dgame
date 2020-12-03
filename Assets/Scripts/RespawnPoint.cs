using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPoint : MonoBehaviour
{
    public GameObject ball;
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
            ballScript.restartingVelocity = new Vector3(1, -1, 0);
            ballScript.restartingPositon = gameObject.transform.position;
            green = true;
            GetComponent<Renderer>().material.SetColor("_Color", Color.green);
            GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.green);
        }
    }
}
