using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Movement variables
    [Header("Movement")]
    public float moveSpeed = 5f;
    public float smoothSpeed = 0.125f;

    // Jump variables
    [Header("Jump")]
    public float jumpForce = 10f;
    private int extraJumps;
    public int extraJumpsValue = 1; // Number of extra jumps allowed (1 for double jump)

    private bool isGrounded;

    // Ground check variables
    [Header("Ground Check")]
    public Transform groundCheck;
    public float checkRadius = 0.2f;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private Animator animator;

    private Vector2 currentVelocity;
    private float moveInput_cache = 1;
    private float moveInput = 0;
    private Vector3 position_cache;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        extraJumps = extraJumpsValue;
    }

    private void FixedUpdate()
    {
        // Handle horizontal movement
        moveInput = Input.GetAxisRaw("Horizontal");
        if (moveInput != moveInput_cache && moveInput != 0)
            moveInput_cache = moveInput;

        var velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
        rb.velocity = Vector2.SmoothDamp(rb.velocity, velocity, ref currentVelocity, smoothSpeed);


        // Check if the player is grounded
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);
    }

    private void Update()
    {
        // Reset extra jumps when grounded
        if (isGrounded)
        {
            extraJumps = extraJumpsValue;
        }

        // Handle jumping
        if (Input.GetButtonDown("Jump"))
        {
            if (extraJumps > 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                extraJumps--;
            }
            else if (isGrounded && extraJumps == 0)
            {
                // Allow jumping when grounded and no extra jumps are left
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }
        }

        // Flip the player
        transform.localScale = new Vector3(moveInput_cache, 1, 1);

        // Animation
        if(moveInput != 0 && isGrounded)
        {
            animator.SetBool("IsMoving", true);
        }
        else
        {
            animator.SetBool("IsMoving", false);
        }
    }
}
