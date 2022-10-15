using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    [SerializeField]
    private TimeManager _timeManager;
    [SerializeField]
    private GameObject _gamePanel;

    [StateEnterMethod("Base.GameSubState.GameState")]
    public void OnEnter()
    {
        _timeManager.timer.StartTimer();
        _gamePanel.SetActive(true);
    }

    [StateExitMethod("Base.GameSubState.GameState")]
    public void OnExit(Collision collision)
    {
        _gamePanel.SetActive(false);
    }

}
