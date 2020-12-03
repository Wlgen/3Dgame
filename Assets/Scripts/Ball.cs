﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    float _speedBall;
    Rigidbody _rigidBody;
    public Vector3 _velocity;
    bool inCollision;
    ParticleSystem _particles;

    void Start()
    {
        inCollision = false;
        _speedBall = 10f;
        _rigidBody = GetComponent<Rigidbody>();
        _velocity = new Vector3(1f, 1f, 0f).normalized * _speedBall;
        _rigidBody.velocity = _velocity;
        _particles = GetComponent<ParticleSystem>();
    }

    void Update()
    {
        if (!inCollision && Input.GetKeyDown(KeyCode.Space))
        {
            _velocity = new Vector3(_velocity.x, -_velocity.y, _velocity.z);
            _rigidBody.velocity = _velocity;
            _particles.Play();
            Invoke("StopParticles", 0.1f);
        }
    }

    void FixedUpdate()
    {
        _rigidBody.velocity = _velocity.normalized * _speedBall;
    }

    private void OnCollisionEnter(Collision collision)
    {
        inCollision = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        inCollision = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 8)
        {
            Destroy(other.gameObject);
            GameManager.Instance.SwitchState(GameManager.State.LEVELCOMPLETED);
        }
    }

    public void setVelocity(Vector3 velocity) { _velocity = velocity; }

    private void StopParticles()
    {
        _particles.Stop();
    }
}
