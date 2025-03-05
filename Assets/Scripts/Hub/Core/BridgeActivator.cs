using UnityEngine;

public class BridgeActivator : MonoBehaviour
{
    [SerializeField] private BoxCollider2D lakeCollider;
    [SerializeField] private GameObject[] OtherStatueObj;

    private bool flag;

    private void Awake()
    {
        flag = true;

        foreach(GameObject g in OtherStatueObj)
            if(!g.activeInHierarchy)
                flag = false;

        lakeCollider.enabled = flag;
        gameObject.SetActive(flag);
    }
}
