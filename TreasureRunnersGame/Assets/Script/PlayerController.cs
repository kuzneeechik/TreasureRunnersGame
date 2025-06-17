using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    public float Speed;
    public float JumpForse;
    private float Move;

    public string LeftKey;
    public string RightKey;
    public string UpKey;

    private Rigidbody2D rb;

    private bool facingRight = true;

    private bool IsGrounded;
    public Transform FeetPos;
    public float CheckRadius;
    public LayerMask Ground;

    private Animator animator;

    private float padding = 0.5f;
    private float minX, maxX, maxY;

    private Camera mainCamera;

    private float wallCheckDistance = 0.1f;
    private int lastDirection = 0;
    private bool blockMoving = false;
    
    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        mainCamera = Camera.main;

        Vector2 bottomLeft = mainCamera.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 topRight = mainCamera.ViewportToWorldPoint(new Vector2(1, 1));

        minX = bottomLeft.x + padding;
        maxX = topRight.x - padding;
        maxY = topRight.y - padding;
    }

    private void FixedUpdate()
    {
        float Move = 0f;

        bool blockLeft = Physics2D.Raycast(transform.position, Vector2.left, wallCheckDistance, Ground);
        bool blockRight = Physics2D.Raycast(transform.position, Vector2.right, wallCheckDistance, Ground);

        if (Input.GetKey(LeftKey))
        {
            Move = -1f;

            if (lastDirection != -1)
            {
                blockMoving = false;
            }

            lastDirection = -1;

            if (blockLeft)
            {
                blockMoving = true;
            }
        } 
        else if (Input.GetKey(RightKey))
        {
            Move = 1f;

            if (lastDirection != 1)
            {
                blockMoving = false;
            }

            lastDirection = 1;

            if (blockRight)
            {
                blockMoving = true;
            }
        }
        else
        {
            blockMoving = false;
            lastDirection = 0;
        }

        if (!blockMoving)
        {
            rb.linearVelocity = new Vector2(Move * Speed, rb.linearVelocity.y);
        }
        else
        {
            rb.linearVelocity = new Vector2(0f, rb.linearVelocity.y);
        }

        animator.SetBool("isRunning", Move != 0);

        if (!facingRight && Move > 0)
        {
            Flip();
        }
        else if (facingRight && Move < 0)
        {
            Flip();
        }

        Vector2 pos = rb.position;
        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        pos.y = Mathf.Min(pos.y, maxY);
        rb.position = pos;
    }

    private void Update()
    {
        IsGrounded = Physics2D.OverlapCircle(FeetPos.position, CheckRadius, Ground);

        if (IsGrounded && Input.GetKeyDown(UpKey))
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, JumpForse);
        }

        animator.SetBool("isJumping", !IsGrounded);
    }

    void Flip()
    {
        facingRight = !facingRight;

        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}
