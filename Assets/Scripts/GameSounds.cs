using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSounds : MonoBehaviour
{

    public AudioSource _mainTheme;
    public AudioSource _titleTheme;
    public AudioSource _ballChangeDirection;
    public AudioSource _wallImpactWall;
    public AudioSource _deathSound;
    public AudioSource _endGameTheme;
    public AudioSource _trialOpenSound;
    public AudioSource _trialChangeDirection;
    public AudioSource _trialClosed;
    public AudioSource _clickButtonMenu;

    AudioSource _currentAudio;
    public static GameSounds Instance { get; private set; }
    void Start()
    {
        Instance = this;
        _currentAudio = _titleTheme;
        _currentAudio.Play();
    }
    public void playMainTheme()
    {
        if(_currentAudio != _mainTheme)
        {
            _currentAudio.Stop();
            _currentAudio = _mainTheme;
            _currentAudio.Play();
        }
    }

    public void playTitleTheme()
    {
        if (_currentAudio != _titleTheme)
        {
            _currentAudio.Stop();
            _currentAudio = _titleTheme;
            _currentAudio.Play();
        }
    }

    public void playEndGameTheme()
    {
        if (_currentAudio != _endGameTheme)
        {
            _currentAudio.Stop();
            _currentAudio = _endGameTheme;
            _currentAudio.Play();
        }
    }

    public void playBallChangeDirection()
    {
        _ballChangeDirection.Play();
    }

    public void playBallImapctWall() {
        _wallImpactWall.Play();
    }

    public void playDeathSound()
    {
        _deathSound.Play();
    }

    public void playTrialOpenSound()
    {
        _trialOpenSound.Play();
    }
    public void playTrialChangeDirection()
    {
        _trialChangeDirection.Play();
    }
    public void playTrialClosed()
    {
        _trialClosed.Play();
    }
    public void playClickButtonMenu()
    {
        _clickButtonMenu.Play();
    }
}
