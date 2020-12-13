using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailEnabler : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        GameObject.Find("Ball").GetComponent<Ball>().addTail();
    }
}
