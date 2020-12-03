using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollisionRight : MonoBehaviour
{
    public GameObject parent;
    Ball parentBall;

    void Start()
    {
        parentBall = parent.GetComponent<Ball>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Bounce"))
        {
            parentBall._velocity = new Vector3(-System.Math.Abs(parentBall._velocity.x), parentBall._velocity.y, 0).normalized;
        }
    }
}
