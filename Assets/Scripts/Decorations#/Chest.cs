using UnityEngine;

public class Chest : MonoBehaviour
{
    private Animator animator;
    private bool playerNear = false;
    private bool opened = false;
    private bool itemSpawned = false;

    public GameObject itemPrefab; // предмет у сундуку
    public Transform spawnPoint;  // точка появи предмета

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (playerNear && Input.GetKeyDown(KeyCode.E))
        {
            if (!opened)
            {
                animator.SetTrigger("Open");
                SpawnItem();
                opened = true;
            }
            else
            {
                animator.SetTrigger("Close");
                opened = false;
            }
        }
    }

    void SpawnItem()
    {
        if (itemPrefab != null && !itemSpawned)
        {
            float direction = Random.value < 0.5f ? -0.4f : 0.4f; // трохи вліво або вправо
            Vector2 offset = new Vector2(direction, -0.3f); // трохи вниз

            Instantiate(itemPrefab, (Vector2)spawnPoint.position + offset, Quaternion.identity);

            itemSpawned = true;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            playerNear = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            playerNear = false;
    }
}