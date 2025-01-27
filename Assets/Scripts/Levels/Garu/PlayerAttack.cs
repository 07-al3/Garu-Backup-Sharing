using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] projectiles;
    [SerializeField] private float attackCooldown;

    private float lastAttack;
    private Animator animator;
    private PlayerMovement movementInstance;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        movementInstance = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0) && lastAttack > attackCooldown && canAttack())
        {
            animator.SetTrigger("shoot");
            lastAttack = 0;
        }
        lastAttack += Time.deltaTime;
    }

    private void activateProjectile()
    {
        foreach(GameObject x in projectiles)
        {
            if(!x.activeInHierarchy)
            {
                x.transform.position = firePoint.position;
                x.GetComponent<GaruProjectile>().setDirection(Mathf.Sign(transform.localScale.x));
                return;
            }
        }
        projectiles[0].SetActive(false);
        projectiles[0].GetComponent<GaruProjectile>().setDirection(Mathf.Sign(transform.localScale.x));
    }

    private bool canAttack()
    {
        return !movementInstance.onWall && movementInstance.isGrounded;
    }
}