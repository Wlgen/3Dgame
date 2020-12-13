using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text levelText;

    public GameObject panelMenu;
    public GameObject panelPlay;
    public GameObject panelLevelCompleted;
    public GameObject panelGameOver;
    public GameObject panelInstructions;
    public GameObject panelCredits;

    public GameObject[] levels;

    public static GameManager Instance { get; private set; }

    public enum State { MENU, INST, CREDITS, INIT, PLAY, LEVELCOMPLETED, LOADLEVEL, GAMEOVER }
    State _state;
    GameObject _currentLevel;
    //bool _isSwitchingState;

    private int _level;

    public int Level
    {
        get { return _level; }
        set
        {
            _level = value;
            levelText.text = "LEVEL: " + _level;
        }
    }

    public void PlayClicked()
    {
        SwitchState(State.INIT);
    }

    public void MenuClicked()
    {
        SwitchState(State.MENU);
    }

    public void InstClicked()
    {
        SwitchState(State.INST);
    }

    public void CreditsClicked()
    {
        SwitchState(State.CREDITS);
    }

    void Start()
    {
        Instance = this;
        SwitchState(State.MENU);
    }


    public void SwitchState(State newState, float delay = 0)
    {
        StartCoroutine(SwitchDelay(newState, delay));
    }

    IEnumerator SwitchDelay(State newState, float delay)
    {
       // _isSwitchingState = true;
        yield return new WaitForSeconds(delay);
        EndState();
        _state = newState;
        BeginState(newState);
       // _isSwitchingState = false;
    }


    void BeginState(State newState)
    {
        switch (newState)
        {
            case State.MENU:
                Cursor.visible = true;
                panelMenu.SetActive(true);
                GameSounds.Instance.playTitleTheme();
                break;
            case State.INST:
                panelInstructions.SetActive(true);
                break;
            case State.CREDITS:
                Cursor.visible = true;
                panelCredits.SetActive(true);
                break;
            case State.INIT:
                Cursor.visible = false;
                panelPlay.SetActive(true);
                Level = 0;
                if (_currentLevel != null)
                {
                    Destroy(_currentLevel);
                }
                SwitchState(State.LOADLEVEL);
                break;
            case State.PLAY:
                panelPlay.SetActive(true);
                GameSounds.Instance.playMainTheme();
                break;
            case State.LEVELCOMPLETED:
                Destroy(_currentLevel);
                Level++;
                float timeS = 0f;
                if (Level < levels.Length)
                {
                    panelLevelCompleted.SetActive(true);
                    timeS = 2f;
                }
                SwitchState(State.LOADLEVEL, timeS);
                break;
            case State.LOADLEVEL:
                if (Level >= levels.Length)
                {
                    SwitchState(State.GAMEOVER);
                }
                else
                {
                    _currentLevel = Instantiate(levels[Level]);
                    SwitchState(State.PLAY);
                }
                break;
            case State.GAMEOVER:
                panelGameOver.SetActive(true);
                SwitchState(State.CREDITS, 2.5f);
                break;
        }
    }

    void Update()
    {
        switch (_state)
        {
            case State.MENU:
                break;
            case State.INST:
                break;
            case State.CREDITS:
                break;
            case State.INIT:
                break;
            case State.PLAY:
                break;
            case State.LEVELCOMPLETED:
                break;
            case State.LOADLEVEL:
                break;
            case State.GAMEOVER:
                break;
        }
    }

    void EndState()
    {
        switch (_state)
        {
            case State.MENU:
                panelMenu.SetActive(false);
                break;
            case State.INST:
                panelInstructions.SetActive(false);
                break;
            case State.CREDITS:
                panelCredits.SetActive(false);
                break;
            case State.INIT:
                break;
            case State.PLAY:
                panelPlay.SetActive(false);
                break;
            case State.LEVELCOMPLETED:
                panelLevelCompleted.SetActive(false);
                break;
            case State.LOADLEVEL:
                break;
            case State.GAMEOVER:
                panelPlay.SetActive(false);
                panelGameOver.SetActive(false);
                break;
        }
    }
}
