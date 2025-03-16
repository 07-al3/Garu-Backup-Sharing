using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class TramaManager : MonoBehaviour
{
    [SerializeField] private GameObject[] texts;
    private int index;

    private void Awake()
    {
        index = 0;
        StartCoroutine(routineDef());
    }

    private IEnumerator routineDef()
    {
        if(index >= texts.Length)
            SceneManager.LoadScene(1);
        else
        {
            texts[index].SetActive(true);
            yield return new WaitForSeconds(17);        
            texts[index].SetActive(false);
            index++;
            StartCoroutine(routineDef());
        }
    }
}
