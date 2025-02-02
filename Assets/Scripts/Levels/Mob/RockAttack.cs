using UnityEngine;

public class RockAttack : MonoBehaviour
{
    [SerializeField] private float attackCoolDown;
    [SerializeField] private CircleCollider2D circleColl;

    private Animator anim;
    private float defCollider;
    private float lastAttack;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        defCollider = circleColl.radius;
    }

    private void Update()
    {
        if(attackCoolDown < lastAttack)
        {
            lastAttack = 0;
            attack();
        }
        else
        {
            lastAttack += Time.deltaTime;
            circleColl.radius = defCollider;
        }
    }

    private void attack()
    {
        anim.SetTrigger("attack");
        circleColl.radius = 0.5f;
    }
}
