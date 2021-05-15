using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRenderer : MonoBehaviour
{
    public Material ShaderMat { get; set; }


    void OnRenderImage(RenderTexture source, RenderTexture destination)
    {

        if (ShaderMat != null)
        {
            Graphics.Blit(source, destination, ShaderMat);
            return;
        }
        
        Graphics.Blit(source, destination);
    }


}
