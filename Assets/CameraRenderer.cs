using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class CameraRenderer : MonoBehaviour
{
    private const float TIME_TO_FADE = 5;

    private Material _shader_material;
    
    private float _power;
    private float _increments = -1f;

    public void FadeIn(Material mat)
    {
        _power = 0;
        _shader_material = mat;
        _increments = 1.0f;
    }

    public void FadeOut()
    {
        _power = 1f;
        _increments = -1f;
    }

    void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        calculate_power();
        
        if (_power == 0f)
        {
            _shader_material = null;
        }

        if (_shader_material == null)
        {
            Graphics.Blit(source, destination);
            return;
        }

        Graphics.Blit(source, destination, _shader_material);
        return;
    }

    private void calculate_power()
    {
        if (_shader_material == null)
        {
            return;
        }

        _power = Mathf.Clamp(_power + (_increments * Time.deltaTime / TIME_TO_FADE), 0f, 1.0f);
        _shader_material.SetFloat("_Power", _power);
    }
}
