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

    private Rigidbody2D Rb;

    private bool FacingRight = true;

    private bool IsGrounded;
    public Transform FeetPos;
    public float CheckRadius;
    public LayerMask Ground;

    public Animator Animator;

    private float Padding = 0.5f;
    private float MinX, MaxX, MaxY;

    private Camera MainCamera;

    private float WallCheckDistance = 0.1f;
    private int LastDirection = 0;
    private bool BlockMoving = false;

    public bool IsAlive = true;
    private float Deep = -6f;
    
    private void Start()
    {
        Animator = GetComponent<Animator>();
        Rb = GetComponent<Rigidbody2D>();
        MainCamera = Camera.main;

        Vector2 bottomLeft = MainCamera.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 topRight = MainCamera.ViewportToWorldPoint(new Vector2(1, 1));

        MinX = bottomLeft.x + Padding;
        MaxX = topRight.x - Padding;
        MaxY = topRight.y - Padding;

        Animator.SetBool("isAlive", true);
    }

    private void FixedUpdate()
    {
        if (!IsAlive)
        {
            return;

            //меню вылазит
        }

        float Move = 0f;

        bool blockLeft = Physics2D.Raycast(transform.position, Vector2.left, WallCheckDistance, Ground);
        bool blockRight = Physics2D.Raycast(transform.position, Vector2.right, WallCheckDistance, Ground);

        if (Input.GetKey(LeftKey))
        {
            Move = -1f;

            if (LastDirection != -1)
            {
                BlockMoving = false;
            }

            LastDirection = -1;

            if (blockLeft)
            {
                BlockMoving = true;
            }
        } 
        else if (Input.GetKey(RightKey))
        {
            Move = 1f;

            if (LastDirection != 1)
            {
                BlockMoving = false;
            }

            LastDirection = 1;

            if (blockRight)
            {
                BlockMoving = true;
            }
        }
        else
        {
            BlockMoving = false;
            LastDirection = 0;
        }

        if (!BlockMoving)
        {
            Rb.linearVelocity = new Vector2(Move * Speed, Rb.linearVelocity.y);
        }
        else
        {
            Rb.linearVelocity = new Vector2(0f, Rb.linearVelocity.y);
        }

        Animator.SetBool("isRunning", Move != 0);

        if (!FacingRight && Move > 0)
        {
            Flip();
        }
        else if (FacingRight && Move < 0)
        {
            Flip();
        }

        Vector2 pos = Rb.position;
        pos.x = Mathf.Clamp(pos.x, MinX, MaxX);
        pos.y = Mathf.Min(pos.y, MaxY);
        Rb.position = pos;
    }

    private void Update()
    {
        if (!IsAlive)
        {
            return;
        }

        IsGrounded = Physics2D.OverlapCircle(FeetPos.position, CheckRadius, Ground);

        if (IsGrounded && Input.GetKeyDown(UpKey))
        {
            Rb.linearVelocity = new Vector2(Rb.linearVelocity.x, JumpForse);
        }

        Animator.SetBool("isJumping", !IsGrounded);

        if (transform.position.y < Deep)
        {
            IsAlive = false;
        }
    }

    void Flip()
    {
        FacingRight = !FacingRight;

        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}
