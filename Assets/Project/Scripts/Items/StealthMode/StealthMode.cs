using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class StealthMode : MonoBehaviour
{
    public static void StealthOn(GameObject hotate)
    {
        // AudioSourceがstaticでないため、音をここで出すことができない。

        var skinnedMeshRenderer = hotate.GetComponent<Renderer>();

        for (int i = 0; i < skinnedMeshRenderer.materials.Length; i++)
        {
            skinnedMeshRenderer.materials[i].color = new Color(
                skinnedMeshRenderer.materials[i].color.r, 
                skinnedMeshRenderer.materials[i].color.g,
                skinnedMeshRenderer.materials[i].color.b,
                0);
            skinnedMeshRenderer.materials[i].renderQueue = (int)RenderQueue.Transparent - 1;
        }
    }

    public static void StealthOff(GameObject hotate)
    {
        // AudioSourceがstaticでないため、音をここで出すことができない。

        var skinnedMeshRenderer = hotate.GetComponent<Renderer>();

        for (int i = 0; i < skinnedMeshRenderer.materials.Length; i++)
        {
            skinnedMeshRenderer.materials[i].color = new Color(
                skinnedMeshRenderer.materials[i].color.r,
                skinnedMeshRenderer.materials[i].color.g,
                skinnedMeshRenderer.materials[i].color.b,
                255);
            skinnedMeshRenderer.materials[i].renderQueue = (int)RenderQueue.Transparent;
        }
    }
}
