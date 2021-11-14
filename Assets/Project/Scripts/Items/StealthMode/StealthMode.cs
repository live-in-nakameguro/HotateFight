using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StealthMode : MonoBehaviour
{
    public static void Stealth(GameObject hotate)
    {
        // AudioSource‚ªstatic‚Å‚È‚¢‚½‚ßA‰¹‚ğ‚±‚±‚Åo‚·‚±‚Æ‚ª‚Å‚«‚È‚¢B

        var skinnedMeshRenderer = hotate.GetComponent<Renderer>();

        for (int i = 0; i < skinnedMeshRenderer.materials.Length; i++)
        {
            Debug.Log(skinnedMeshRenderer.materials[i].name);
            Debug.Log(skinnedMeshRenderer.materials[i].color);
            hotate.GetComponent<Renderer>().materials[i].color = new Color(
                skinnedMeshRenderer.materials[i].color.r, 
                skinnedMeshRenderer.materials[i].color.g,
                skinnedMeshRenderer.materials[i].color.b,
                0);
            Debug.Log(skinnedMeshRenderer.materials[i].color);
        }
    }
}
