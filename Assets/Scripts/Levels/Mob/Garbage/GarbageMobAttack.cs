using UnityEngine;
using System.Collections;

public class GarbageMobAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown;

    private Animator anim;
    private float lastAttack;

    private void Awake()
    {
        anim = GetComponentInParent<Animator>();
    }

    private void Update()
    {
        lastAttack += Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag.Equals("Player") && lastAttack > attackCooldown)
        {
            lastAttack = 0;
            checkScale(other);
            anim.SetTrigger("Attack");
        }
        else if(other.tag.Equals("Player"))           
        {
            Physics2D.IgnoreCollision(gameObject.GetComponent<BoxCollider2D>(), other);
            StartCoroutine(stopIgnoring(other));
        }
    }

    private void checkScale(Collider2D other)
    {
        transform.localScale = other.transform.position.x > transform.position.x ? new Vector2(-Mathf.Abs(transform.localScale.x), transform.localScale.y) : new Vector2(Mathf.Abs(transform.localScale.x), transform.localScale.y);
    }

    private IEnumerator stopIgnoring(Collider2D other)
    {
        yield return new WaitForSeconds(1);
        Physics2D.IgnoreCollision(gameObject.GetComponent<BoxCollider2D>(), other, true);
    }
}
