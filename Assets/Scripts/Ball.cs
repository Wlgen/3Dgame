using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    float _speedBall;
    Rigidbody _rigidBody;
    Vector3 _velocity;

    void Start()
    {
        _speedBall = 10f;
        _rigidBody = GetComponent<Rigidbody>();
        _rigidBody.velocity = new Vector3(1f, 1f, 0f) * _speedBall;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rigidBody.velocity = new Vector3(_rigidBody.velocity.x, -_rigidBody.velocity.y, _rigidBody.velocity.z) * _speedBall;
        }
    }
    void FixedUpdate()
    {
        _rigidBody.velocity = _rigidBody.velocity.normalized * _speedBall;
        _velocity = _rigidBody.velocity;
    }

    private void OnCollisionEnter(Collision collision) { 
        _rigidBody.velocity = Vector3.Reflect(_velocity, collision.contacts[0].normal);
    }
}
