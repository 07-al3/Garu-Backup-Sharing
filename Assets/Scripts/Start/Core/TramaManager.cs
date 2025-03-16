using UnityEngine;
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
        if(index == 7)
            gameObject.SetActive(false);
        texts[index++].SetActive(true);
        yield return new WaitForSeconds(12);
        StartCoroutine(routineDef());
    }
}
