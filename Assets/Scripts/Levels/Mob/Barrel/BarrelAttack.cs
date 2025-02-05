using UnityEngine;
using System.Collections;

public class BarrelAttack : MonoBehaviour
{
    private Animator anim;
    private CircleCollider2D circleColl;
    private float speed;

    [SerializeField] private float distanceOfSearch;
    [SerializeField] private float distanceOfExplosion;
    [SerializeField] private LayerMask playerLayer;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        circleColl = GetComponent<CircleCollider2D>();
        speed = GetComponent<MobPatrol>().speed;
    }

    private void Update()
    {
        RaycastHit2D rightRay = searchPlayerOnRight();
        RaycastHit2D leftRay = searchPlayerOnLeft();

        Collider2D rightColl = rightRay.collider;
        Collider2D leftColl = leftRay.collider;

        if(rightColl != null || leftColl != null)
            GetComponent<BehavioursSetter>().setActive(false);
        else
            GetComponent<BehavioursSetter>().setActive(true);

        if(rightColl != null)
            checkForExploding(rightColl);
        else if(leftColl != null)
            checkForExploding(leftColl);
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

    private void checkForExploding(Collider2D coll)
    {
        if(Mathf.Abs(coll.gameObject.transform.position.x - transform.position.x) < distanceOfExplosion)
            anim.SetTrigger("Explode");
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
        yield return new WaitForSeconds(0.5f);
        gameObject.SetActive(false);
    }
}