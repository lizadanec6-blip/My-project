using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 7f;

    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask ground;

    private Rigidbody2D rb;
    private Animator anim;
    private bool isGrounded;

    private Vector3 respawnPoint;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        respawnPoint = transform.position;
    }

    void Update()
    {
        float move = Input.GetAxis("Horizontal");

        rb.linearVelocity = new Vector2(move * speed, rb.linearVelocity.y);

        anim.SetFloat("Speed", Mathf.Abs(move));

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, ground);

        anim.SetBool("IsJumping", !isGrounded);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        Vector3 scale = transform.localScale;

        if (move > 0)
            scale.x = Mathf.Abs(scale.x);
        else if (move < 0)
            scale.x = -Mathf.Abs(scale.x);

        transform.localScale = scale;

        if (transform.position.y < -10f)
        {
            Respawn();
        }
    }

    public void Respawn()
    {
        transform.position = respawnPoint;
        rb.linearVelocity = Vector2.zero;
    }
}