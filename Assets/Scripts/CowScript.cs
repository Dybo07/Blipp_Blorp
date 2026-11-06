using UnityEngine;

public class cowScript : MonoBehaviour
{
    public GameManager gameManager;

    [SerializeField] private float wallCheckDistance = 0.3f;
    [SerializeField] private float edgeCheckDistance = 0.5f;
    public LayerMask groundLayer;
    private SpriteRenderer sprite;  
    private Rigidbody2D rb;
    private Collider2D col;
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float direction = 1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("SceneManager").GetComponent<GameManager>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
    }
    void Update()
    {
        // Check for walls
        Vector2 wallOrigin = new Vector2(
            direction == 1 ? col.bounds.max.x : col.bounds.min.x,
            col.bounds.center.y
        );

        RaycastHit2D wallHit = Physics2D.Raycast(
            wallOrigin,
            Vector2.right * direction,
            wallCheckDistance,
            groundLayer
        );

        // Check for ground ahead
        Vector2 groundOrigin = new Vector2(
            direction == 1 ? col.bounds.max.x + edgeCheckDistance * 0.5f
                           : col.bounds.min.x - edgeCheckDistance * 0.5f,
            col.bounds.min.y + 0.05f
        );

        RaycastHit2D groundHit = Physics2D.Raycast(
            groundOrigin,
            Vector2.down,
            edgeCheckDistance,
            groundLayer
        );

        if (wallHit.collider != null || groundHit.collider == null)
        {
            direction *= -1;
        }

        sprite.flipX = direction == 1;
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(direction * moveSpeed, rb.linearVelocity.y);

    }
    //Cow pickup system

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gameManager.IncrementCowCount();
            Destroy(gameObject);
        }
    }
}
