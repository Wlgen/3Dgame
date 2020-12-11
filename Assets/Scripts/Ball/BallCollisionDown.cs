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
        if (other.CompareTag("Bounce"))
        {
            parentBall.setCollisionDown(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Bounce"))
        {
            parentBall.setCollisionDown(false);
        }
    }
}
