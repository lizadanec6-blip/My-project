using UnityEngine;

public class GhostAI : MonoBehaviour
{
    public Transform player;          // принцеса
    public float speed = 2f;          // швидкість привида
    public float chaseDistance = 3f;  // радіус переслідування

    private Vector3 playerSpawn;      //принцесa
    private Vector3 ghostSpawn;       //привида
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (player != null)
            playerSpawn = player.position;

        ghostSpawn = transform.position;
    }

    void Update()
    {
        if (player == null) return;

        float distance = Vector2.Distance(transform.position, player.position);

        if (distance < chaseDistance)
        {
            // рухаємося до принцеси
            transform.position = Vector2.MoveTowards(
                transform.position,
                player.position,
                speed * Time.deltaTime
            );

            if (animator != null)
                animator.SetBool("isRunning", true);

            // переворот спрайта
            if (player.position.x < transform.position.x)
                spriteRenderer.flipX = true;   // дивимося вліво
            else
                spriteRenderer.flipX = false;  // дивимося вправо
        }
        else
        {
            if (animator != null)
                animator.SetBool("isRunning", false);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            player.position = playerSpawn;
            transform.position = ghostSpawn;

            if (animator != null)
                animator.SetBool("isRunning", false);
        }
    }
}