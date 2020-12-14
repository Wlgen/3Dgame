using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollisionDown : MonoBehaviour
{
    public GameObject parent;
    public GameObject ballRenderer;
    Animator ballAnimator;
    Ball parentBall;

    void Start()
    {
        parentBall = parent.GetComponent<Ball>();
        ballAnimator = ballRenderer.GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bounce") || (other.CompareTag("Death") && parentBall.isGod() && other.gameObject.layer != 8) || (other.CompareTag("Trail Door") && !parentBall.itIsTailed()))
        {
            GameSounds.Instance.playBallImapctWall();
            if(parentBall.itIsTailed()) GameSounds.Instance.playTrialChangeDirection();
            parentBall.setCollisionDown(true);
            ballAnimator.SetTrigger("CollisionDown");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Bounce") || (other.CompareTag("Death") && parentBall.isGod() && other.gameObject.layer != 8) || (other.CompareTag("Trail Door") && !parentBall.itIsTailed()))
        {
            parentBall.setCollisionDown(true);
        }
    }

    /*private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Bounce") || (other.CompareTag("Death") && parentBall.isGod() && other.gameObject.layer != 8) || (other.CompareTag("Trail Door") && !parentBall.itIsTailed()))
        {
            parentBall.setCollisionDown(false);
        }
    }*/
}
