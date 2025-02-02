using UnityEngine;
using System.Collections;

public class BarrelBehaviour : MonoBehaviour
{
    private Animator anim;
    private bool movingRight;
    private CircleCollider2D circleColl;

    [Header("Patrol Parameters")]
    [SerializeField] private Transform rightEdge;
    [SerializeField] private Transform leftEdge;
    [SerializeField] private Transform initialPos;

    [Header("Movement and Attack Parameters")]
    [SerializeField] private float distanceOfSearch;
    [SerializeField] private float distanceOfExplosion;
    [SerializeField] private float speed;
    [SerializeField] private LayerMask playerLayer;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        circleColl = GetComponent<CircleCollider2D>();
        transform.position = initialPos.position;
    }

    private void Update()
    {
        RaycastHit2D rightRay = searchPlayerOnRight();
        RaycastHit2D leftRay = searchPlayerOnLeft();

        Collider2D rightColl = rightRay.collider;
        Collider2D leftColl = leftRay.collider;

        if(rightColl != null)
            checkForExploding(rightColl);
        else if(leftColl != null)
            checkForExploding(leftColl);
        else
            patrol();
    }

    private RaycastHit2D searchPlayerOnRight()
    {
        RaycastHit2D ray = Physics2D.BoxCast(circleColl.bounds.center, circleColl.bounds.size, 0, new Vector2(Mathf.Abs(transform.localScale.x), 0), distanceOfSearch, playerLayer);
        return ray;
    }

    private RaycastHit2D searchPlayerOnLeft()
    {
        RaycastHit2D ray = Physics2D.BoxCast(circleColl.bounds.center, circleColl.bounds.size, 0, new Vector2(-Mathf.Abs(transform.localScale.x), 0), distanceOfSearch, playerLayer);
        return ray;
    }

    private void patrol()
    {
        if(Mathf.Abs(transform.position.x - rightEdge.position.x) < 0.01)
            movingRight = false;
        else if(Mathf.Abs(transform.position.x - leftEdge.position.x) < 0.01)
           movingRight = true;

        transform.localScale = movingRight ? new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y) : new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y);

        Vector3 target = movingRight ? rightEdge.position : leftEdge.position;
        Vector3 direction = (target - transform.position).normalized;
        transform.Translate(speed * Time.deltaTime * direction);
    }

    private void checkForExploding(Collider2D coll)
    {
        if(Mathf.Abs(coll.gameObject.transform.position.x - transform.position.x) < distanceOfExplosion)
            anim.SetTrigger("explode");
        else 
        {
            transform.Translate(speed * Time.deltaTime * (coll.gameObject.transform.position - transform.position).normalized);
            transform.localScale = coll.transform.position.x > transform.position.x ? new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y) : new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y);
        }
    }

    public void increaseRadius()
    {
        circleColl.radius = 0.3f;
        StartCoroutine(waitAndturnOff());
    }

    private IEnumerator waitAndturnOff()
    {
        yield return new WaitForSeconds(2);
        gameObject.SetActive(false);
    }
}