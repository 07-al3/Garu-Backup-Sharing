using UnityEngine;

public class GarbageMobAlert : MonoBehaviour
{
    private BoxCollider2D boxColl;
    [SerializeField] private GameObject otherAl;

    private void Awake()
    {
        boxColl = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag.Equals("Player"))
        {
            GetComponentInParent<Animator>().SetTrigger("Discover");
            gameObject.SetActive(false);
            otherAl.gameObject.SetActive(false);
        }
    }
}
