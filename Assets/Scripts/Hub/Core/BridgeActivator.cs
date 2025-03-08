using UnityEngine;

public class BridgeActivator : MonoBehaviour
{
    [SerializeField] private BoxCollider2D lakeCollider;
    [SerializeField] private GameObject[] OtherStatueObj;

    private int conta;

    private void Awake()
    {
        conta = 0;

        foreach(GameObject g in OtherStatueObj)
            if(g.activeInHierarchy)
                conta++;

        lakeCollider.enabled = conta != 3;
        gameObject.SetActive(conta == 3);
    }
}
