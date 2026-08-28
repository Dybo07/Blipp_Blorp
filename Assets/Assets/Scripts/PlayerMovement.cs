using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Gun")]
    public GameObject gunPrefab;


    [Header("Camera")]
    [SerializeField] private Camera playerCamera;
    [SerializeField] private Vector2 cameraOffset;
    [SerializeField] private float smoothSpeed = 5f;

    [Header("Movement")]
    public float moveSpeed = 5f;

    public float jumpForce = 10f;
    public float jumpCutMultiplier = 0.5f;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;
    public float fallMultiplier = 2.5f;
    private float moveInput;
    private bool isGrounded;

    [Header("Audio/SFX")]
    private AudioSource audioSourcePlayer;
    public AudioClip[] jumpSound;
    public AudioClip walking;


    [Header("Other")]
    public GameObject spritePlayer;
    private Rigidbody2D rb;
    public float hitPoints;




    void Start()
    {
        playerCamera = Camera.main;
        rb = GetComponent<Rigidbody2D>();
        audioSourcePlayer = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            gunPrefab.SetActive(!gunPrefab.activeSelf);

        }

        moveInput = Input.GetAxisRaw("Horizontal");

        spritePlayer.GetComponent<Animator>().SetBool("Walking", moveInput != 0);
        
            isGrounded = Physics2D.OverlapCircle(
                groundCheck.position,
                groundCheckRadius,
                groundLayer
            );

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);

            audioSourcePlayer.PlayOneShot(jumpSound[Random.Range(0, 2)]);
        }

        // Jump released early
        if (Input.GetKeyUp(KeyCode.Space) && rb.linearVelocity.y > 0)
        {
            rb.linearVelocity = new Vector2(
                rb.linearVelocity.x,
                rb.linearVelocity.y * jumpCutMultiplier
            );
        }

        if (rb.linearVelocity.y < 0)
        {
            rb.linearVelocity += Vector2.up * Physics2D.gravity.y *
                           (fallMultiplier - 1) *
                           Time.fixedDeltaTime;
        }
        // Flip the sprite based on movement direction
        if (moveInput > 0)
            spritePlayer.GetComponent<SpriteRenderer>().flipX = false;
        else if (moveInput < 0)
            spritePlayer.GetComponent<SpriteRenderer>().flipX = true;

        //Hitpoint check
        if(hitPoints <= 0)
        {
            Destroy(gameObject);
            UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
        }
    }

    void FixedUpdate()
    {
        
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);
    }
    private void LateUpdate()
    {
        if (playerCamera == null) return;

        Vector3 targetPosition = new Vector3(
            transform.position.x + cameraOffset.x,
            transform.position.y + cameraOffset.y,
            playerCamera.transform.position.z
        );

        playerCamera.transform.position = Vector3.Lerp(
            playerCamera.transform.position,
            targetPosition,
            smoothSpeed * Time.deltaTime
        );

        
    }
}