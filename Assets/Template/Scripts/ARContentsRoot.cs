using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARContentsRoot : MonoBehaviour
{
    private GameObject _arContents;

    private void OnEnable()
    {
        //ARContentsというタグのついたGameObjectを探し、見つけたら_arContentsに代入
        _arContents = GameObject.FindGameObjectWithTag("ARContents");
        //ARContentsを子オブジェクトにする（ARCountensをマーカーに追従させるため）
        _arContents.transform.parent = transform;
        //ScanCompleteStateにステートを遷移する。
        //マーカーが認識されるとARCountentRootがスポーンする
        //OnEnableでこれを実行することで、スキャン完了を検知し、ステートの遷移をする
        StateManager.Instance.ChangeState(State.ScanCompletedState);
    }

    private void OnDisable()
    {
        // transform.DetachChildren();
    }
}

