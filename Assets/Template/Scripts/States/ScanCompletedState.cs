using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScanCompletedState : MonoBehaviour
{
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

    [StateEnterMethod("Base.ScanCompletedState")]
    public void OnEnter()
    {
        StartCoroutine(OnEnterCoroutine());
    }

    private IEnumerator OnEnterCoroutine()
    {
        _cup.gameObject.SetActive(true);
        //アクティブにしてすぐUVUnrapがうまくできなかったので、1フレーム待つ
        yield return null;
        //蓋のテクスチャを、カメラ画像から投影したものに置き換える
        _cup.SetTextureFromView();
        //カップを開けるアニメーションの開始
        _cup.OpenLid(_lidDuration, _lidDelay);
        //カップの中身を取り出すアニメーションの開始
        _cup.RevealInside(_insideDuration, _insideDelay);
    }
}
