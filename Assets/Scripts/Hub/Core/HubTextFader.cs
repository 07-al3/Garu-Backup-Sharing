using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HubTextFader : MonoBehaviour
{
    [SerializeField] private Text text; 
    [SerializeField] private float fadeDuration; 

    private Color color;

    private void Awake()
    {
        StartCoroutine(fade());
    }

    private IEnumerator fade()
    {
        color = text.color;
        color.a = 0f; 
        text.color = color;

        for(float t = 0; t < fadeDuration; t += Time.deltaTime)
        {
            float alpha = Mathf.Lerp(0, 1, t / fadeDuration);
            text.color = new Color(color.r, color.g, color.b, alpha);
            yield return null;
        }
    }
}
