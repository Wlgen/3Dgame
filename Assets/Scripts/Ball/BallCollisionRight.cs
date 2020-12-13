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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bounce") || (other.CompareTag("Death") && parentBall.isGod()))
        {
            GameSounds.Instance.playBallImapctWall();
            parentBall.setCollisionRight(true);
            parentBall.changeDirectionWheel();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Bounce") || (other.CompareTag("Death") && parentBall.isGod()))
        {
            parentBall.setCollisionRight(false);
        }
    }
}
