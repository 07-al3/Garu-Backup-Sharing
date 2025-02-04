using UnityEngine;

public class GaruProjectile : MonoBehaviour
{
    [SerializeField] private float speed = 1;
    [SerializeField] private float lifeTime = 5;

    private float direction;
    private bool hit;
    private float life;
    
    private Animator animator;
    private Rigidbody2D body;
    private BoxCollider2D boxCollider;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if(gameObject.activeInHierarchy && !hit)
        {
            body.linearVelocity = new Vector2(speed * direction, 0);
            life += Time.deltaTime;
            if(life > lifeTime) 
                gameObject.SetActive(false);
        }    
    }

    private void fireProjectile()
    {
        animator.SetTrigger("Fire"); 
    }

    private void deactivateProjectile()
    {
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        hit = true;
        body.linearVelocity = Vector2.zero;
        animator.SetTrigger("Hit");
    }

    public void setDirection(float d)
    {
        direction = d;
        life = 0;
        hit = false;
        gameObject.SetActive(true);

        transform.localScale = (Mathf.Sign(transform.localScale.x) != direction)? new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z) : transform.localScale;
    }
}