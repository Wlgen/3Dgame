using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGoal : MonoBehaviour
{
    public ParticleSystem _confetti;

    private void Start()
    {
        _confetti.Stop();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            Destroy(GameObject.FindGameObjectWithTag("Ball"));
            _confetti.Play();
            Invoke("changeLevel", 5f);
        }
    }

    private void changeLevel()
    {
        _confetti.Stop();
        GameManager.Instance.SwitchState(GameManager.State.LEVELCOMPLETED);
    }
}
