using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollisionUp : MonoBehaviour
{
    public GameObject parent;
    Ball parentBall;

    void Start()
    {
        parentBall = parent.GetComponent<Ball>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bounce") || (other.CompareTag("Death") && parentBall.isGod()))
        {
            parentBall.setCollisionUp(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Bounce") || (other.CompareTag("Death") && parentBall.isGod()))
        {
            parentBall.setCollisionUp(false);
        }
    }
}
