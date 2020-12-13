using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollisionLeft : MonoBehaviour
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
            parentBall.setCollisionLeft(true);
            parentBall.changeDirectionWheel();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Bounce") || (other.CompareTag("Death") && parentBall.isGod()))
        {
            parentBall.setCollisionLeft(false);
        }
    }
}
