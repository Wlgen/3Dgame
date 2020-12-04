using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Vector3 restartingVelocity;
    public Vector3 restartingPositon;
    float _speedBall;
    Rigidbody _rigidBody;
    public Vector3 _velocity;
    bool inCollision;

    void Start()
    {
        inCollision = false;
        _speedBall = 10f;
        _rigidBody = GetComponent<Rigidbody>();
        _velocity = new Vector3(1f, 1f, 0f).normalized * _speedBall;
        _rigidBody.velocity = _velocity;
    }

    void Update()
    {
        if (!inCollision && Input.GetKeyDown(KeyCode.Space))
        {
            _velocity = new Vector3(_velocity.x, -_velocity.y, _velocity.z);
            _rigidBody.velocity = _velocity;
        }
    }
    void FixedUpdate()
    {
        _rigidBody.velocity = _velocity.normalized * _speedBall;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Death"))
        {
            _rigidBody.transform.position = restartingPositon;
            _velocity = restartingVelocity.normalized;
        }
        inCollision = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        inCollision = false;
    }

    public void setRestartingVelocity(Vector3 velocity) { _velocity = velocity; }
}
