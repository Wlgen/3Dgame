using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailDoor : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            if (collision.gameObject.GetComponent<Ball>().itIsTailed())
            {
                Destroy(gameObject);
                collision.gameObject.GetComponent<Ball>().destroyTrail();
            }
        }
    }
}
