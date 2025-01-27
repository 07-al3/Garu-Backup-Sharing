using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Parameters")]
    [SerializeField] private float speed;
    [SerializeField] private float jumpPower;

    [Header("Wall Check")]
    [SerializeField] private LayerMask wallLayer;
    [SerializeField] private float wallCheckOffset;

    [Header("Ground Check")]
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float groundCheckOffset;

    private Animator animator;
    private Rigidbody2D body;
    private BoxCollider2D box;

    private float horizontalInput;
    private bool isFalling;
    public bool isGrounded {get; private set;}
    public bool onWall {get; private set;}

    private void Awake()
    {
        animator = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
        box = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        setIsGrounded();
        setOnWall();

        checkForKeys();

        if(onWall && body.linearVelocity.y != 0)
        {
            animator.SetBool("clinging", true);
            resetVelocity();
            setGravityScale(0);
        }
        else if(!onWall)
        {
            animator.SetBool("clinging", false);
            setGravityScale(1);
        }

        horizontalInput = Input.GetAxis("Horizontal");
        if(horizontalInput != 0)
        {
            transform.localScale = new Vector3(Mathf.Sign(horizontalInput) * Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z); 
            animator.SetBool("walking", true);
            body.linearVelocity = new Vector2(horizontalInput * speed, body.linearVelocity.y);
        }
        else
            animator.SetBool("walking", false);

        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(isGrounded)
                jump(horizontalInput * speed, jumpPower);
            else if(onWall)
            {
                animator.SetBool("clinging", false);

                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
                body.linearVelocity = new Vector2(Mathf.Sign(transform.localScale.x) * speed, jumpPower);

                setGravityScale(1);
                animator.SetTrigger("jump");
            }
        }

        if(body.linearVelocity.y < 0 && !isFalling)
        {
            animator.SetTrigger("land");
            isFalling = true;
        }

        if(isGrounded)
        {
            isFalling = false;
            animator.ResetTrigger("land");
        }
    }

    private void setIsGrounded()
    {
        RaycastHit2D groundCheck = Physics2D.BoxCast(box.bounds.center, box.bounds.size, 0, new Vector2(0, transform.localScale.y), groundCheckOffset, groundLayer);
        isGrounded = groundCheck.collider != null ? true : false;
    }

    private void setOnWall()
    {
        RaycastHit2D wallCheck = Physics2D.BoxCast(box.bounds.center, box.bounds.size, 0, new Vector2(transform.localScale.x, 0), wallCheckOffset, wallLayer);
        onWall = wallCheck.collider != null ? true : false;
    }

    private void checkForKeys()
    {
        if(Input.GetKeyDown(KeyCode.Q))
            Time.timeScale = 0.25f; 
        if(Input.GetKeyDown(KeyCode.E))
            Time.timeScale = 1; 

        if(Input.GetKeyDown(KeyCode.T)) 
        {
            if(onWall)
            {
                resetVelocity();
                body.AddForce(new Vector2(50 * -Mathf.Sign(transform.localScale.x), 25 * transform.localScale.y), ForceMode2D.Force); 
            }
            animator.SetTrigger("hurt");
        }
        if(Input.GetKeyDown(KeyCode.M))
        {
            resetVelocity();
            animator.SetTrigger("die");
            
        }
    }

    private void jump(float x, float y)
    {
        animator.SetTrigger("jump");
        body.linearVelocity = new Vector2(body.linearVelocity.x, 0); 
        body.AddForce(new Vector2(x, y), ForceMode2D.Impulse);
    }

    private void setGravityScale(int value)
    {
        body.gravityScale = value;
    }

    private void resetVelocity()
    {
        body.linearVelocity = Vector2.zero;
    }
}