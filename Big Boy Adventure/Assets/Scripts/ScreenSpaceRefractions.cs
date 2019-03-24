using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[ExecuteInEditMode]
public class ScreenSpaceRefractions : MonoBehaviour
{
    [HideInInspector]
    [SerializeField]
    private Camera _camera;
    private int _downResFactor = 1;

    [SerializeField]
    [Range(0, 1)]
    private float _refractionVisibility = 0;
    [SerializeField]
    [Range(0, 0.1f)]
    private float _refractionMagnitude = 0;

    private string _globalTextureName = "_GlobalRefractionTex";
    private string _globalVisibilityName = "_GlobalVisibility";
    private string _globalMagnitudeName = "_GlobalRefractionMag";

    public void VisibilityChange(float value)
    {
        _refractionVisibility = value;
        Shader.SetGlobalFloat(_globalVisibilityName, _refractionVisibility);
    }

    public void MagnitudeChange(float value)
    {
        _refractionMagnitude = value;
        Shader.SetGlobalFloat(_globalMagnitudeName, _refractionMagnitude);
    }

    void OnEnable()
    {
        GenerateRT();
        Shader.SetGlobalFloat(_globalVisibilityName, _refractionVisibility);
        Shader.SetGlobalFloat(_globalMagnitudeName, _refractionMagnitude);
    }

    void OnValidate()
    {
        Shader.SetGlobalFloat(_globalVisibilityName, _refractionVisibility);
        Shader.SetGlobalFloat(_globalMagnitudeName, _refractionMagnitude);
    }

    void GenerateRT()
    {
        _camera = GetComponent<Camera>();

        if (_camera.targetTexture != null)
        {
            RenderTexture temp = _camera.targetTexture;

            _camera.targetTexture = null;
            DestroyImmediate(temp);
        }

        _camera.targetTexture = new RenderTexture(_camera.pixelWidth >> _downResFactor, _camera.pixelHeight >> _downResFactor, 16);
        _camera.targetTexture.filterMode = FilterMode.Bilinear;

        Shader.SetGlobalTexture(_globalTextureName, _camera.targetTexture);
    }
}