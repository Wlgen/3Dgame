using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGoal : MonoBehaviour
{
    public ParticleSystem _confetti;
    AudioSource _audioSource;

    private void Start()
    {
        _confetti.Stop();
        _audioSource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            Destroy(GameObject.FindGameObjectWithTag("Ball"));
            _audioSource.Play();
            _confetti.Play();
            Invoke("changeLevel", 3.6f);
        }
    }

    private void changeLevel()
    {
        _confetti.Stop();
        GameManager.Instance.SwitchState(GameManager.State.LEVELCOMPLETED);
    }
}
