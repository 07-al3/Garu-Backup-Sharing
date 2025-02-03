using UnityEngine;

public class GarbageMobAlert : MonoBehaviour
{
    private BoxCollider2D boxColl;

    private void Awake()
    {
        boxColl = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag.Equals("Player"))
        {
            GetComponentInParent<Animator>().SetTrigger("discover");
            gameObject.SetActive(false);
        }
    }
}
