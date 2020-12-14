using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizPaddle : MonoBehaviour
{
    public Vector3 StartDirection = Vector3.right;
    private GameObject ball;
    private Rigidbody _rigidbody;
    private float speed, speedchase;
    private Vector3 velocity, prePosition, prevVelocity;

    void Start()
    {
        speed = 5f;
        speedchase = 2 * speed;
        velocity = StartDirection * speed;
        ball = GameObject.Find("Ball");
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.velocity = velocity;
        prePosition = transform.position;
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Bounce"))
        {
            velocity = -velocity;
            _rigidbody.velocity = velocity;
        }
        if (collision.gameObject.CompareTag("Ball"))
        {
            prevVelocity = velocity;
            velocity = Vector3.zero;
            _rigidbody.velocity = velocity;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            velocity = prevVelocity;
            _rigidbody.velocity = velocity;
        }
    }

    void FixedUpdate()
    {
        if (ball!= null) { 
            if (prePosition == transform.position)
            {
                velocity = -velocity;
            }
            if (System.Math.Abs(ball.transform.position.y - transform.position.y) > 3)
            {
                _rigidbody.velocity = velocity;
            }
            else
            {
                if (System.Math.Abs(ball.transform.position.x - transform.position.x) < 10)
                {
                    _rigidbody.velocity = new Vector3(ball.transform.position.x - transform.position.x, 0, 0);
                    if (_rigidbody.velocity.magnitude > 1)
                    {
                        _rigidbody.velocity = _rigidbody.velocity.normalized * speedchase;
                    }
                }
            }
            prePosition = transform.position;
        }
    }
}
