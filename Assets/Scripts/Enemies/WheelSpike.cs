using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelSpike : MonoBehaviour
{
    public Vector3 StartDirection = Vector3.left;
    public float speed;
    private Vector3 velocity;
    private Rigidbody _rigidBody;

    private bool rotate;

    void Start()
    {
        speed = 6f;
        velocity = StartDirection * speed;
        _rigidBody = GetComponent<Rigidbody>();
        _rigidBody.velocity = velocity;
        rotate = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        rotate = false;
        _rigidBody.velocity = velocity;
    }

    private void OnCollisionExit(Collision collision)
    {
        rotate = true;
    }
    // Update is called once per frame
    /*void Update()
    {
        transform.Rotate(0, 0, 50 * Time.deltaTime);
    }*/

    private void FixedUpdate()
    {
        if(rotate) transform.Rotate(0, 0, 130 * Time.deltaTime);
        _rigidBody.velocity = velocity;
    }

    public void changeDirection()
    {
        velocity = -velocity;
        _rigidBody.velocity = velocity;
    }
}
