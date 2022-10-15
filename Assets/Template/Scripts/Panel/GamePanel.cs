using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePanel : MonoBehaviour
{
    public Button HomeButton;
    public GameObject TimesUpLabel;
    public Button FireButton;

    private void OnEnable()
    {
        Initialize();
    }

    public void OnHomeButtonClick()
    {
        StateManager.Instance.ChangeState(State.HomeState);
    }

    private void Initialize()
    {
        TimesUpLabel.SetActive(false);
        HomeButton.gameObject.SetActive(false);
        FireButton.gameObject.SetActive(true);
    }

}
