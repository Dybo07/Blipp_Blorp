using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    [Header("Camera")]
    [SerializeField] private Camera playerCamera;
    [SerializeField] private Vector2 cameraOffset;
    [SerializeField] private float cameraSmoothSpeed = 5f;
    [SerializeField] private float smoothSpeed = 5f;


    public float moveSpeed = 5f;
    public float jumpForce = 10f;

    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;

    public GameObject spritePlayer;

    private Rigidbody2D rb;
    private float moveInput;
    private bool isGrounded;

    void Start()
    {
        playerCamera = Camera.main;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal");

        isGrounded = Physics2D.OverlapCircle(
            groundCheck.position,
            groundCheckRadius,
            groundLayer
        );

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }

        if (moveInput > 0)
            spritePlayer.GetComponent<SpriteRenderer>().flipX = false;
        else if (moveInput < 0)
            spritePlayer.GetComponent<SpriteRenderer>().flipX = true;
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