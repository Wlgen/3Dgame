using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollisionRight : MonoBehaviour
{
    public GameObject parent;
    public GameObject ballRenderer;
    Ball parentBall;
    Animator ballAnimator;

    void Start()
    {
        parentBall = parent.GetComponent<Ball>();
        ballAnimator = ballRenderer.GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bounce") || (other.CompareTag("Death") && parentBall.isGod()) || (other.CompareTag("Trail Door") && !parentBall.itIsTailed()))
        {
            GameSounds.Instance.playBallImapctWall();
            if (parentBall.itIsTailed()) GameSounds.Instance.playTrialChangeDirection();
            parentBall.setCollisionRight(true);
            parentBall.changeDirectionWheel();
            ballAnimator.SetTrigger("CollisionRight");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Bounce") || (other.CompareTag("Death") && parentBall.isGod()) || (other.CompareTag("Trail Door") && !parentBall.itIsTailed()))
        {
            parentBall.setCollisionRight(false);
        }
    }
}
