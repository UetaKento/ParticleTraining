using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ResetTest : MonoBehaviour
{
    [SerializeField]
    private ARSession _arSession;
    [SerializeField]
    private ARCameraManager _arCameraManager;

    public void ResetSession()
    {
        StartCoroutine(ButtonCoroutine());
        
    }

    private IEnumerator ButtonCoroutine()
    {
        _arSession.Reset();
        yield return null;
        _arCameraManager.autoFocusRequested = true;
    }
    //private void Update()
    //{
    //    Debug.Log(_arCameraManager.autoFocusEnabled);
    //}
}
