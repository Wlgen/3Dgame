﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailDoor : MonoBehaviour
{
    public GameObject trailEnabler;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            if (collision.gameObject.GetComponent<Ball>().itIsTailed())
            {
                GameSounds.Instance.playTrialClosed();
                Destroy(gameObject);
                collision.gameObject.GetComponent<Ball>().destroyTrail();
                trailEnabler.GetComponent<TrailEnabler>().openDoor();
            }
        }
    }
}
