using UnityEngine;

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
        winCanvas.SetActive(conta == 4);
    }
}
