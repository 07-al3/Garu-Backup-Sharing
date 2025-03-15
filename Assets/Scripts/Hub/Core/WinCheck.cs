using UnityEngine;
using System.Collections;

public class WinCheck : MonoBehaviour
{
    [SerializeField] private GameObject winCanvas;
    [SerializeField] private GameObject[] statueObjects;

    private int conta;

    private void Awake()
    {
        conta = 0;
        foreach(GameObject obj in statueObjects)
            if(obj.activeInHierarchy)
                conta++;
        if(conta == 4)
            StartCoroutine(waitAndGo());       
    }

    private IEnumerator waitAndGo()
    {
        yield return new WaitForSeconds(4);
        winCanvas.SetActive(true);
    }
}
