using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomePanel : MonoBehaviour
{
    //(スタートボタンのイベントにインスペクタから追加する。)
    //ScanningStateに遷移するメソッド
    public void OnStartButtonClick()
    {
        StateManager.Instance.ChangeState(State.ScanningState);
    }
}
