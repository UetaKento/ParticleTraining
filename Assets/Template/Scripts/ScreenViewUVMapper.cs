using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;


public class ScreenViewUVMapper : MonoBehaviour
{
    public ARCameraManager ARCameraManager
    {
        get => _arCameraManager;
        set => _arCameraManager = value;
    }

    [SerializeField]
    private ARCameraManager _arCameraManager;

    [SerializeField]
    private Texture2D _debugTexture;

    [SerializeField]
    private GameObject _target;

    [SerializeField]
    private GameObject _target2;

    [SerializeField]
    private bool _isSkinnedMesh = true;


    private void OnEnable()
    {
        if (_arCameraManager == null)
            _arCameraManager = FindObjectOfType<ARCameraManager>();

        Instantiate(_target2, new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity);
    }

public void ReplaceTexture()
    {
        Texture2D tex = CaptureTexture();
#if UNITY_EDITOR
        tex = _debugTexture;
#endif
        if (_isSkinnedMesh)
        {
            _target.GetComponent<SkinnedMeshRenderer>().material.mainTexture = tex;
            UVUnwrapFromView(_target.GetComponent<SkinnedMeshRenderer>(), tex);
        }
        else
        {
            _target.GetComponent<MeshRenderer>().material.mainTexture = tex;
            UVUnwrapFromView(_target.GetComponent<MeshFilter>(), tex);
        }

    }

    public NativeArray<byte> CaptureRawColorDate(out XRCpuImage.ConversionParams conversionParams)
    {
        if (_arCameraManager == null || !_arCameraManager.TryAcquireLatestCpuImage(out XRCpuImage image))
        {
            conversionParams = new XRCpuImage.ConversionParams();
            Debug.Log($"camera{_arCameraManager}, cpuImage{_arCameraManager.TryAcquireLatestCpuImage(out XRCpuImage image1)}");
            return new NativeArray<byte>();
        }

        conversionParams = new XRCpuImage.ConversionParams
        {
            inputRect = new RectInt(0, 0, image.width, image.height),
            outputDimensions = new Vector2Int(image.width, image.height),
            outputFormat = TextureFormat.RGBA32,
            transformation = XRCpuImage.Transformation.MirrorY
        };

        int size = image.GetConvertedDataSize(conversionParams);
        var buffer = new NativeArray<byte>(size, Allocator.Temp);
        image.Convert(conversionParams, buffer);
        image.Dispose();
        return buffer;
    }

    public Texture2D CaptureTexture()
    {
        NativeArray<byte> buffer = CaptureRawColorDate(out XRCpuImage.ConversionParams conversionParams);
        if (buffer.Length == 0)
        {
            Debug.Log("buffer length = 0");
            return null;
        }
        Texture2D texture = new Texture2D(
            conversionParams.outputDimensions.x,
            conversionParams.outputDimensions.y,
            conversionParams.outputFormat,
            false);

        texture.filterMode = FilterMode.Bilinear;
        texture.wrapMode = TextureWrapMode.Clamp;

        texture.LoadRawTextureData(buffer);
        texture.Apply();
        buffer.Dispose();

        return texture;
    }


    private void UVUnwrapFromView(MeshFilter meshFilter, Texture2D tex)
    {
        Mesh mesh = meshFilter.mesh;
        Transform transform = meshFilter.transform;
        Camera camera = _arCameraManager.GetComponent<Camera>();

        List<Vector3> verts = new List<Vector3>(mesh.vertexCount);
        mesh.GetVertices(verts);
        List<Vector2> uvs = new List<Vector2>();

        float textureAspect = (float)tex.height / tex.width;
        float screenAspect = (float)Screen.width / Screen.height;
        float aspectFactor = (float)screenAspect / textureAspect;

        float xOffset = (1.0f - aspectFactor) * 0.5f;
        float xFactor = 1.0f / Screen.width * aspectFactor;
        float yFactor = 1.0f / Screen.height;

        Debug.Log("Aspect: " + textureAspect + "  " + screenAspect);

        for (int i = 0; i < verts.Count; i++)
        {
            Vector3 vert = verts[i];
            Vector3 worldPos = transform.TransformPoint(vert);
            Vector3 screenPoint = camera.WorldToScreenPoint(worldPos);
            Vector2 uv = new Vector3(screenPoint.y * yFactor, 1.0f - screenPoint.x * xFactor - xOffset, 0);

            uvs.Add(uv);
        }

        mesh.SetUVs(0, uvs);
    }

    private void UVUnwrapFromView(SkinnedMeshRenderer skinnedMeshRenderer, Texture2D tex)
    {
        Mesh mesh = skinnedMeshRenderer.sharedMesh;
        Transform transform = _target.transform;
        Camera camera = _arCameraManager.GetComponent<Camera>();

        List<Vector3> verts = new List<Vector3>(mesh.vertexCount);
        mesh.GetVertices(verts);
        List<Vector2> uvs = new List<Vector2>();

        float textureAspect = (float)tex.height / tex.width;
        float screenAspect = (float)Screen.width / Screen.height;
        float aspectFactor = (float)screenAspect / textureAspect;

        float xOffset = (1.0f - aspectFactor) * 0.5f;
        float xFactor = 1.0f / Screen.width * aspectFactor;
        float yFactor = 1.0f / Screen.height;

        Debug.Log("Aspect: " + textureAspect + "  " + screenAspect);

        for (int i = 0; i < verts.Count; i++)
        {
            Vector3 vert = verts[i];
            Vector3 worldPos = transform.TransformPoint(vert);
            Vector3 screenPoint = camera.WorldToScreenPoint(worldPos);
            Vector2 uv = new Vector3(screenPoint.y * yFactor, 1.0f - screenPoint.x * xFactor - xOffset, 0);

            uvs.Add(uv);
        }

        mesh.SetUVs(0, uvs);
    }


}
