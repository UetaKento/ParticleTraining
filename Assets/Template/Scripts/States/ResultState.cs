using System.Collections;
using System.Collections.Generic;
using UnityEngine.XR.ARFoundation;
using UnityEngine;

public class ResultState : MonoBehaviour
{
    [SerializeField]
    private GamePanel _gamePanel;
    [SerializeField]
    private CupController _cup;

    [SerializeField]
    private ARSession _arSession;
    [SerializeField]
    private GameObject _arSessionOrigin;

    private GameObject _arContentsRoot;


    [StateEnterMethod("Base.GameSubState.ResultState")]
    public void OnEnter()
    {
        _gamePanel.HomeButton.gameObject.SetActive(true);
    }

    [StateExitMethod("Base.GameSubState.ResultState")]
    public void OnExit()
    {
        _gamePanel.gameObject.SetActive(false);
        _cup.gameObject.SetActive(false);

        DisableARSession();
    }

    private void DisableARSession()
    {
        Destroy(FindObjectOfType<ARTrackedImage>().gameObject);
        _arSession.Reset();
        _arSession.gameObject.SetActive(false);
        _arSessionOrigin.SetActive(false);

    }
}
