using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupController : MonoBehaviour
{
    private ScreenViewUVMapper _uvManager;
    private SkinnedMeshRenderer _skinnedMeshRenderer;
    [SerializeField] private Transform _insideObj;
    [SerializeField] private Transform _startPos;
    [SerializeField] private Transform _endPos;


    private float _openLevel = 0;
    private float _maxLevel = 100;

    public float OpenLevel
    {
        get => _openLevel;
        set
        {
            //0~1の値にする
            _openLevel = Mathf.Min(Mathf.Max(value, 0), _maxLevel);
            //openLevelプロパティを設定したらブレンドの値にも反映されるようにする。
            _skinnedMeshRenderer.SetBlendShapeWeight(0, _openLevel);
        }
    }

    private void OnEnable()
    {
        _uvManager = GetComponent<ScreenViewUVMapper>();
        _skinnedMeshRenderer = GetComponentInChildren<SkinnedMeshRenderer>();
    }

    public void SetTextureFromView()
    {
        //テクスチャをカメラ画像から投影したものに差し替える
        _uvManager.ReplaceTexture();
        //おクルージョンシェーダのαを１にして不透明にする
        _skinnedMeshRenderer.material.SetFloat("_Alpha", 1);
    }

    public void OpenLid(float duration, float delay)
    {
        StartCoroutine(AnimateLidCoroutine(duration, 0, _maxLevel, delay));
    }

    public void CloseLid(float duration, float delay)
    {
        StartCoroutine(AnimateLidCoroutine(duration, _maxLevel, 0, delay));
    }

    public void CloseLid()
    {
        OpenLevel = 0;
    }

    //cupの蓋を開け閉めするコルーティン
    private IEnumerator AnimateLidCoroutine(float duration, float start, float end, float delay)
    {
        //開始時間「delay」秒だけ待つ
        yield return new WaitForSeconds(delay);

        //「duration」秒かけて、Openレベルをstartからendの値にする
        for (float t = 0; t < 1; t += Time.deltaTime / duration)
        {
            OpenLevel = Mathf.Lerp(start, end, t);
            yield return null;
        }
        //deltaTimeで制御したので、最後ピッタリ０や１にならない可能性があるので、endの値をきちんと最後に代入する
        OpenLevel = end;
    }

    public void RevealInside(float duration, float delay)
    {
        StartCoroutine(AnimateIndsideCoroutine(duration, _startPos, _endPos, delay));
    }

    public void HideInside(float duration, float delay)
    {
        StartCoroutine(AnimateIndsideCoroutine(duration, _endPos, _startPos, delay));
    }

    public void HideInside()
    {
        _insideObj.position = _startPos.position;
    }

    //カップの中身のオブジェクトをstart位置からend位置まで「duration」秒かけて移動させるコルーティン
    private IEnumerator AnimateIndsideCoroutine(float duration, Transform start, Transform end, float delay)
    {
        //開始時間「delay」秒だけ待つ
        yield return new WaitForSeconds(delay);

        //「duration」秒かけて、_insideObjのポジションをstartからendの値にする
        for (float t = 0; t < 1; t += Time.deltaTime / duration)
        {
            _insideObj.position = Vector3.Lerp(start.position, end.position, t);
            yield return null;
        }
        //deltaTimeで制御したので、最後ピッタリ０や１にならない可能性があるので、endの値をきちんと最後に代入する
        _insideObj.position = end.position;
    }
}
