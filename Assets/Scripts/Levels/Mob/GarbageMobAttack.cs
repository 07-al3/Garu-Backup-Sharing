using UnityEngine;

public class GarbageMobAttack : MonoBehaviour
{
    private Animator anim;

    private void Awake()
    {
        anim = GetComponentInParent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag.Equals("Player"))
        {
            checkScale(other);
            anim.SetTrigger("attack");
        }
    }

    private void checkScale(Collider2D other)
    {
        transform.localScale = other.transform.position.x > transform.position.x ? new Vector2(-Mathf.Abs(transform.localScale.x), transform.localScale.y) : transform.localScale;
    }
}
