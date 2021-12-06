using UnityEngine;
using UnityEngine.Rendering;
using Common.Utils;

public class StealthMode : MonoBehaviour
{
    GameObject hotate;

    public void StealthOn(GameObject hotate)
    {
        // AudioSourceがstaticでないため、音をここで出すことができない。

        var skinnedMeshRenderer = hotate.GetComponent<Renderer>();

        for (int i = 0; i < skinnedMeshRenderer.materials.Length; i++)
        {
            MaterialUtils.SetBlendMode(skinnedMeshRenderer.materials[i], MaterialUtils.Mode.Fade);

            skinnedMeshRenderer.materials[i].color = new Color(
                skinnedMeshRenderer.materials[i].color.r,
                skinnedMeshRenderer.materials[i].color.g,
                skinnedMeshRenderer.materials[i].color.b,
                0);

            this.hotate = hotate;
        }
    }

    public void InvokeStealthOff()
    {
        Invoke(nameof(StealthOff), 10.0f);
    }

    private void StealthOff()
    {
        // AudioSourceがstaticでないため、音をここで出すことができない。

        var skinnedMeshRenderer = this.hotate.GetComponent<Renderer>();

        for (int i = 0; i < skinnedMeshRenderer.materials.Length; i++)
        {
            MaterialUtils.SetBlendMode(skinnedMeshRenderer.materials[i], MaterialUtils.Mode.Opaque);

            skinnedMeshRenderer.materials[i].color = new Color(
                skinnedMeshRenderer.materials[i].color.r,
                skinnedMeshRenderer.materials[i].color.g,
                skinnedMeshRenderer.materials[i].color.b,
                255);
        }
    }
}
