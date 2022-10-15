using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScanningState : MonoBehaviour
{
    [SerializeField]
    private GameObject _scanningPanel;
    [SerializeField]
    private GameObject _mainCamera;
    [SerializeField]
    private GameObject _arSession;
    [SerializeField]
    private GameObject _arSessionOrigin;

    [StateEnterMethod("Base.ScanningState")]
    public void OnEnter()
    {
        _scanningPanel.SetActive(true);
        StartARSession();
    }

    [StateExitMethod("Base.ScanningState")]
    public void OnExit()
    {
        _scanningPanel.SetActive(false);
    }

    private void StartARSession()
    {
        _arSession.SetActive(true);
        _arSessionOrigin.SetActive(true);
        _mainCamera.SetActive(false);
    }
}
