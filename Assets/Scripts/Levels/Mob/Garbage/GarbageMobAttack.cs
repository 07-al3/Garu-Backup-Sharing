using UnityEngine;

public class GarbageMobAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown;

    private Animator anim;
    private float lastAttack;

    private void Awake()
    {
        anim = GetComponentInParent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("Player") && lastAttack > attackCooldown)
        {
            lastAttack = 0;
            checkScale(other);
            anim.SetTrigger("Attack");
        }
        else
        {
            lastAttack += Time.deltaTime;
            //Physics.IgnoreCollision(other.GetComponent<Collider>(), GetComponent<BoxCollider2D>().GetComponent<Collider>());
        }
    }

    private void checkScale(Collider2D other)
    {
        transform.localScale = other.transform.position.x > transform.position.x ? new Vector2(-Mathf.Abs(transform.localScale.x), transform.localScale.y) : new Vector2(Mathf.Abs(transform.localScale.x), transform.localScale.y);
    }
}
