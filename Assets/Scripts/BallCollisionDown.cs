using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollisionDown : MonoBehaviour
{
    public GameObject parent;
    Ball parentBall;

    void Start()
    {
        parentBall = parent.GetComponent<Ball>();
    }

    private void OnTriggerEnter(Collider other)
    {
        parentBall._velocity = new Vector3(parentBall._velocity.x, System.Math.Abs(parentBall._velocity.y), parentBall._velocity.z).normalized;
    }
}
