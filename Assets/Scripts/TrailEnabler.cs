using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailEnabler : MonoBehaviour
{
    bool doorOpened = false;
    private void OnTriggerExit(Collider other)
    {
        if (!doorOpened)
        {
            GameObject ball = GameObject.Find("Ball");
            if (other.CompareTag("Ball"))
            {
                if (!ball.GetComponent<Ball>().itIsTailed())
                {
                    ball.GetComponent<Ball>().addTail();
                }
            }
        }
    }

    public void openDoor()
    {
        doorOpened = true;
    }
}
