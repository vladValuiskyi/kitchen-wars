using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour
{
    public float speed = 20f;
    private Rigidbody2D rb;
    public bool isFacingRight = true;
    public float jumpPower = 2000;
    public bool isGrounded = false;
    public Transform groundCheck;
    public float groundRadius = 0.2f;
    public LayerMask whatIsGround;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = CrossPlatformInputManager.GetAxis("Horizontal");

        rb.velocity = new Vector2(moveX * speed, rb.velocity.y);

        if (moveX > 0 && !isFacingRight)
        {
            Flip();
        }
        else if (moveX < 0 && isFacingRight)
        {
            Flip();
        }

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        if (!isGrounded)
        {
            return;
        }

        if (CrossPlatformInputManager.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector2.up * jumpPower);
        }
    }

    void Flip()
    {
        isFacingRight = !isFacingRight;

        Vector3 theScale = transform.localScale;

        theScale.x *= -1;

        transform.localScale = theScale;
    }
}
