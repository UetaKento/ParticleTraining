using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[DefaultExecutionOrder(-1)]
public class Timer : MonoBehaviour
{
    private bool _isCounting = false;
    public bool isCounting => _isCounting;

    private float _totalTime = 180;
    public float TotalTime => _totalTime;

    //分表記にした時のためのプロパティ
    public int Sec
    {
        get { return (int)_totalTime % 60; }
    }
    //分表記にした時のためのプロパティ
    public int Min
    {
        get { return (int)_totalTime / 60; }
    }

    //タイマーの値が更新される度に実行されるイベント
    public event Action<int> OnTimeUpdate;
    //タイマーの値がゼロになった時に実行されるイベント
    public event Action OnTimesUp;

    //タイマーの時間をセットするメソッド
    public void SetTimer(float totalTime)
    {
        _totalTime = totalTime;
        OnTimeUpdate?.Invoke((int)_totalTime);
    }

    public void SetTimer(int min, int sec)
    {
        _totalTime = 60 * min + sec;
        OnTimeUpdate?.Invoke((int)_totalTime);
    }

    public void AddTime(float deltaTime)
    {
        _totalTime += deltaTime;
        OnTimeUpdate?.Invoke((int)_totalTime);
    }

    //残り時間をログ
    public void WhatTime()
    {
        Debug.Log(Min + ":" + string.Format("{0:D2}", Sec));
    }

    //カウントダウンを開始するメソッド
    public void StartTimer()
    {
        StartCoroutine(CountDownCoroutine());

    }

    public void StopTimer()
    {
        StopCoroutine(CountDownCoroutine());
        _isCounting = false;
    }

    //カウントダウンを行コルーティン
    private IEnumerator CountDownCoroutine()
    {
        _isCounting = true;
        var oneSec = new WaitForSecondsRealtime(1);

        //totalTimeがゼロになるまでカウントダウン
        while(_totalTime > 0)
        {
            //1秒まつ
            yield return oneSec;
            //1秒ひく
            _totalTime--;
            //OnTimeUpdateを実行する。
            //？はnullチェック(イベントが空でもエラーにならない)
            OnTimeUpdate?.Invoke((int)_totalTime);
        }
        _isCounting = false;
        //_totalTimeがゼロになったのでOnTimeUpを実行する
        OnTimesUp?.Invoke();
    }

    //秒表記をを分表記に変えるメソッド
    //例）128秒　→ 2:08
    public static string ToMinitNotation(int t)
    {
        return t + ":" + string.Format("{0:D2}", t % 60);
    }
}