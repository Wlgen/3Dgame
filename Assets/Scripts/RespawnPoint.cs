﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPoint : MonoBehaviour
{
    public Vector3 restartingVelocity = new Vector3(-1, -1, 0);
    public int restartingCamera;
    public GameObject ball;
    public Material greenCheckpoint;
    public GameObject C;
    Ball ballScript;
    bool green = false;
    AudioSource _audioSource;
    void Start()
    {
        ballScript = ball.GetComponent<Ball>();
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!green && other.CompareTag("Ball"))
        {
            ballScript.restartingVelocity = restartingVelocity.normalized;
            ballScript.restartingPositon = gameObject.transform.position;
            ballScript.restartingCamera = restartingCamera;
            green = true;
            C.GetComponent<Renderer>().material = greenCheckpoint;
            _audioSource.Play();
        }
    }
}
