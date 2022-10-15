using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimeManager : MonoBehaviour
{
    [SerializeField]
    private int _initialValue = 180;
    [SerializeField]
    private Slider _slider;
    [SerializeField]
    private TextMeshProUGUI _timerLabelHome;
    [SerializeField]
    private TextMeshProUGUI _timerLabelGame;
    [SerializeField]
    private RectTransform _timerGuage;
    [SerializeField]
    private float _angularVelocity = 360;
    [SerializeField]
    private int _sliderFactor = 30;

    [HideInInspector]
    public Timer timer;

    private void OnEnable()
    {
        timer = GetComponent<Timer>();
        //OnTimeUpdatにSetLabelメソッドを追加
        //タイマーの数字が更新されるたびにタイマーの文字が更新る
        timer.OnTimeUpdate += SetTimerLabel;
        //OnTimesUpにChangeStateToTimeUpを追加
        //タイマーが0になった時に、TimesUpStateに遷移
        timer.OnTimesUp += ChangeStateToTimesUp;

    }

    private void OnDisable()
    {
        timer.OnTimeUpdate -= SetTimerLabel;
        timer.OnTimesUp -= ChangeStateToTimesUp;
    }

    //0.2秒ごとに実行されるメソッド
    private void FixedUpdate()
    {
        if (timer.isCounting)
        {
            _timerGuage.Rotate(Vector3.back, _angularVelocity * Time.fixedDeltaTime);
        }
    }

    //スライダーのInspectorに登録してあげる
    public void OnSliderValueChanged(float t)
    {
        //スライダーの値に_sliderFactor = 30をかける。30秒刻み
        t *= _sliderFactor;
        //タイマーをセット
        timer.SetTimer((int)t);
    }

    private void SetTimerLabel(int t)
    {
        //分表記にしたい場合はTimer.ToMinitNotation()で変換する
        //_timerLabelHome.text = Timer.ToMinitNotation(t);
        _timerLabelHome.text = t.ToString();
        _timerLabelGame.text = t.ToString();
    }

    //TimeUpStateにステートを遷移する
    private void ChangeStateToTimesUp()
    {
        StateManager.Instance.ChangeState(State.TimesUpState);
    }

    //タイマーの値とスライダーの位置を初期状態に戻すメソッド
    public void Reset()
    {
        timer.SetTimer(_initialValue);
        _slider.value = _initialValue;
    }
}
