using UnityEngine;

public class BarrelBehaviour : MonoBehaviour
{
    private Animator anim;
    private bool movingRight;

    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private Transform rightEdge;
    [SerializeField] private Transform leftEdge;
    [SerializeField] private float distance;
    [SerializeField] private float speed;
    [SerializeField] private float distanceOfExplosion;
    [SerializeField] private Transform initialPos;
    [SerializeField] private CircleCollider2D circleColl;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        transform.position = initialPos.position;
    }

    private void Update()
    {
        RaycastHit2D ray = searchPlayer();
        Collider2D coll = ray.collider;

        if(coll != null)
        {
            if(coll.gameObject.transform.position.x - transform.position.x < distanceOfExplosion)
                anim.SetTrigger("explode");


            // raggio esplosione e danni + deattivazione da funzione a fine animazione


            else
                transform.Translate((coll.gameObject.transform.position - transform.position).normalized * speed * Time.deltaTime);
        }
        else
        {
            if(Mathf.Abs(transform.position.x - rightEdge.position.x) < 0.01)
                movingRight = false;
            else if(Mathf.Abs(transform.position.x - leftEdge.position.x) < 0.01)
                movingRight = true;

            transform.localScale = movingRight ? new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y) : new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y);

            Vector3 target = movingRight ? rightEdge.position : leftEdge.position;
            Vector3 direction = (target - transform.position).normalized;
            transform.Translate(direction * speed * Time.deltaTime);
        }
    }

    private RaycastHit2D searchPlayer()
    {
        RaycastHit2D ray = Physics2D.BoxCast(circleColl.bounds.center, circleColl.bounds.size, 0, new Vector2(transform.localScale.x, 0), distance, playerLayer);
        return ray;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Vector2 direction = new Vector2(-Mathf.Sign(transform.localScale.x), 0);
        Vector3 finalCenter = circleColl.bounds.center + (Vector3)(direction * distance);
        Gizmos.DrawWireCube(finalCenter, circleColl.bounds.size);
    }
}