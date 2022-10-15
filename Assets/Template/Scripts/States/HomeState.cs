using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeState : MonoBehaviour
{
    [SerializeField]
    private GameObject _mainCamera;
    [SerializeField]
    private GameObject _homePanel;
    [SerializeField]
    private TimeManager _timeManager;

    [StateEnterMethod("Base.HomeState")]
    public void OnEnter()
    {
        _mainCamera.SetActive(true);
        _timeManager.Reset();
        _homePanel.SetActive(true);
    }

    [StateExitMethod("Base.HomeState")]
    public void OnExit()
    {
        _homePanel.SetActive(false);
    }

    //[StateUpdateMethod("Base.HomeState")]
    //public void OnUpdate()
    //{
    //    Debug.Log("You are in HomeState");
    //}
}
