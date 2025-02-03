using UnityEngine;
using System.Collections;

public class RockAttack : MonoBehaviour
{
    [SerializeField] private float attackCoolDown;

    private CircleCollider2D circleColl;
    private Animator anim;
    private float defCollider;
    private float lastAttack;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        circleColl = GetComponent<CircleCollider2D>();
        defCollider = circleColl.radius;
    }

    private void Update()
    {
        if(attackCoolDown < lastAttack)
        {
            lastAttack = 0;
            StartCoroutine(attack());
        }
        else
            lastAttack += Time.deltaTime;
    }

    private IEnumerator attack()
    {
        circleColl.radius = 0.35f;
        anim.SetTrigger("attack");
        yield return new WaitForSeconds(1);
        circleColl.radius = defCollider;
    }
}
