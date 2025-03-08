using UnityEngine;
using System.Collections;

public class IntroAnimation : MonoBehaviour
{
    private void Awake()
    {
        StartCoroutine(waitForActivation());
    }

    private IEnumerator waitForActivation()
    {
        yield return new WaitForSeconds(3.5f);
        GetComponent<Animator>().SetTrigger("Activate");
    }
}
