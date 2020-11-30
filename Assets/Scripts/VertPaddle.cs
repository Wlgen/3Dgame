using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VertPaddle : MonoBehaviour
{
    Rigidbody _rigidbody;
    float _yspeed;

    void Start()
    {
        _yspeed = 0.1f;
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.name != "Ball")
        {
            _yspeed = -_yspeed;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _rigidbody.MovePosition(new Vector3(_rigidbody.position.x, _rigidbody.position.y + _yspeed, _rigidbody.position.z));
    }
}
