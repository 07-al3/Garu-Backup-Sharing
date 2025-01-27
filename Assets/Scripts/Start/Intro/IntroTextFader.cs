using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class IntroTextFader : MonoBehaviour
{
    [SerializeField] private Text text; 
    [SerializeField] private float fadeDuration; 
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject parentGameObject;

    public void Awake()
    {
        StartCoroutine(fade(false, 0, 1));
        StartCoroutine(fade(true, 1, 0));
        StartCoroutine(load());
    }

    private IEnumerator fade(bool wait, float firstLerp, float secondLerp)
    {
        yield return new WaitForSeconds(wait? fadeDuration + 3: 0);

        Color color = text.color;

        if(wait)
        {
            color.a = 0f; 
            text.color = color;
        }

        for(float t = 0; t < fadeDuration; t += Time.deltaTime)
        {
            float alpha = Mathf.Lerp(firstLerp, secondLerp, t / fadeDuration);
            text.color = new Color(color.r, color.g, color.b, alpha);
            yield return null;
        }

        if(!wait)
            text.color = new Color(color.r, color.g, color.b, 1f);
    }

    private IEnumerator load()
    {
        yield return new WaitForSeconds(fadeDuration * 2 + 3);
        mainMenu.SetActive(true);
        yield return new WaitForSeconds(2);
        parentGameObject.SetActive(false);
    }
}
