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
            parentBall.setCollisionRight(true);
            parentBall.changeDirectionWheel();
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.CompareTag("Bounce"))
        {
            parentBall.setCollisionRight(false);
        }
    }
}
