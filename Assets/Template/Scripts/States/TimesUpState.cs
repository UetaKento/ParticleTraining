using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimesUpState : MonoBehaviour
{
    [SerializeField]
    private GamePanel _gamePanel;
    [SerializeField]
    private CupController _cup;

    [SerializeField]
    private float _lidDuration = 1f;
    [SerializeField]
    private float _lidDelay = 0.5f;

    [SerializeField]
    private float _insideDuration = 0.5f;
    [SerializeField]
    private float _insideDelay = 1.5f;

    [StateEnterMethod("Base.GameSubState.TimesUpState")]
    public void OnEnter()
    {
        _gamePanel.TimesUpLabel.SetActive(true);
        _gamePanel.FireButton.gameObject.SetActive(false);

        _cup.CloseLid(_lidDuration, _lidDelay);
        _cup.HideInside(_insideDuration, _insideDelay);
    }
}
