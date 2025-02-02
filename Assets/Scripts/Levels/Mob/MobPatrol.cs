using UnityEngine;

public class MobPatrol : MonoBehaviour
{
    [SerializeField] private Transform rightEdge;
    [SerializeField] private Transform leftEdge;
    [SerializeField] private Transform initialPos;
    
    public float speed;
    private bool movingRight;
    
    private void Awake()
    {
        transform.position = initialPos.position;
    }

    private void Update()
    {
        patrol();
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
}
