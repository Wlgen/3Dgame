using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    float _speedBall;
    Rigidbody _rigidBody;
    public Vector3 _velocity;

    void Start()
    {
        _speedBall = 10f;
        _rigidBody = GetComponent<Rigidbody>();
        _velocity = new Vector3(1f, 1f, 0f).normalized * _speedBall;
        _rigidBody.velocity = _velocity;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _velocity = new Vector3(_velocity.x, -_velocity.y, _velocity.z);
            _rigidBody.velocity = _velocity;
        }
    }
    void FixedUpdate()
    {
        _rigidBody.velocity = _velocity;
    }

    public void setVelocity(Vector3 velocity) { _velocity = velocity; }
}
