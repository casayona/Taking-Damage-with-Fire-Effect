using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class FireScreen : MonoBehaviour
{
    public Volume postProcessingVolume; 
    private Vignette vignette; 

    private void Start()
    {
        if (postProcessingVolume.profile.TryGet(out vignette))
        {
            vignette.intensity.value = 0f; 
        }
    }

    public void EnableFireEffect()
    {
        if (vignette != null)
        {
            StopAllCoroutines();
            StartCoroutine(FadeVignette(0f, 0.5f, 0.5f));
        }
    }

    public void DisableFireEffect()
    {
        if (vignette != null)
        {
            StopAllCoroutines();
            StartCoroutine(FadeVignette(0.5f, 0f, 0.5f)); 
        }
    }

    private System.Collections.IEnumerator FadeVignette(float startValue, float endValue, float duration)
    {
        float elapsed = 0f;
        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            vignette.intensity.value = Mathf.Lerp(startValue, endValue, elapsed / duration);
            yield return null;
        }
        vignette.intensity.value = endValue;
    }
}
