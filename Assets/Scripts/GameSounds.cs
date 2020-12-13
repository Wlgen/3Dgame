using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSounds : MonoBehaviour
{

    public AudioSource _mainTheme;
    public AudioSource _titleTheme;

    AudioSource _currentAudio;
    public static GameSounds Instance { get; private set; }
    void Start()
    {
        Instance = this;
        _currentAudio = _titleTheme;
        _currentAudio.Play();
    }
    public void setMainTheme()
    {
        if(_currentAudio != _mainTheme)
        {
            _currentAudio.Stop();
            _currentAudio = _mainTheme;
            _currentAudio.Play();
        }
    }

    public void setTitleTheme()
    {
        if (_currentAudio != _titleTheme)
        {
            _currentAudio.Stop();
            _currentAudio = _titleTheme;
            _currentAudio.Play();
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
