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
            if (other.CompareTag("Ball"))
            {
                if (!other.gameObject.GetComponent<Ball>().itIsTailed())
                {
                    other.gameObject.GetComponent<Ball>().addTail();
                }
            }
        }
    }

    public void openDoor()
    {
        doorOpened = true;
    }
}
