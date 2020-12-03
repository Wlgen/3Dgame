using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGoal : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            Debug.Log("TRIGGERED");
            GameManager.Instance.SwitchState(GameManager.State.LEVELCOMPLETED);
        }
    }
}
