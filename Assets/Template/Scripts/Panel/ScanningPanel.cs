using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScanningPanel : MonoBehaviour
{
    [SerializeField]
    private GameObject _arContentsRoot;
    public void DummyScanComplete()
    {
        var ARContentsRoot = Instantiate(_arContentsRoot);
    }
}
