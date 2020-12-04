using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpikeHoriz : MonoBehaviour
{
    public Vector3 StartDirection = Vector3.left;
    public float speed = 5f;
    private Vector3 velocity;
    private Rigidbody _rigidBody;
    void Start()
    {
        velocity = StartDirection * speed;
        _rigidBody = GetComponent<Rigidbody>();
        _rigidBody.velocity = velocity;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bounce"))
        {
            velocity = -velocity;
            _rigidBody.velocity = velocity;
        }
        _rigidBody.velocity = velocity;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
