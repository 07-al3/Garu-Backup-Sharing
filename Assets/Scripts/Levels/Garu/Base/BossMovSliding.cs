using UnityEngine;

public class BossMovSliding : MonoBehaviour
{
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float groundCheckOffset;

    private BoxCollider2D box;
    private Rigidbody2D body;

    private void Awake()
    {
        box = GetComponent<BoxCollider2D>();
        body = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        RaycastHit2D groundCheck = Physics2D.BoxCast(box.bounds.center, box.bounds.size, 0, new Vector2(0, transform.localScale.y), groundCheckOffset, groundLayer);
        if(groundCheck.collider != null && body.linearVelocity.x == 0 && body.linearVelocity.y == 0)
            body.linearVelocity = new Vector2(0.8f, 0);
    }
}
