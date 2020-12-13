using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCamera : MonoBehaviour
{
    public Vector3[] cameraPositions;
    int actualPosition = 0;
    float speed = 10;

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, cameraPositions[actualPosition], Time.deltaTime * speed);
        Debug.Log(transform.position);
    }

    public void setActualCamera(int cam)
    {
        actualPosition = cam;
    }
}
