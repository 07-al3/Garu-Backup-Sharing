using UnityEngine;

public class HubMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    private float horizontalInput;
    private float verticalInput;

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        if(horizontalInput != 0)
            transform.localScale = new Vector3(Mathf.Sign(horizontalInput) * Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);

        Vector2 movement = new Vector2(horizontalInput * speed * Time.deltaTime, verticalInput * speed * Time.deltaTime);
        if(movement.magnitude > 1)
            movement.Normalize();
          
        animator.SetBool("walk", horizontalInput != 0 || verticalInput != 0);
        transform.Translate(movement);
    }
}