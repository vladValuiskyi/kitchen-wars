using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;
    private Rigidbody2D rb;
    public bool isFacingRight = true;
    public float jumpPower = 6;
    public bool isGrounded = false;
    public Transform groundCheck;
    public float groundRadius = 0.2f;
    public LayerMask whatIsGround;
    public Text deadEndText;
    public bool isAlive = true;
    private BoxCollider2D bc;
    private CapsuleCollider2D cc;
    public Button restartButton;


    // Start is called before the first frame update
    void Start()
    {
        bc = GetComponent<BoxCollider2D>();
        cc = GetComponent<CapsuleCollider2D>();
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
            Debug.Log("not_jump");
            return;
        }

        if (CrossPlatformInputManager.GetButtonDown("Jump"))
        {
            Debug.Log("jump");
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

    public void DieScript()
    {
        isAlive = false;
        rb.velocity = new Vector2(0, rb.velocity.y);
        rb.AddForce(Vector2.up * 2000);
        Destroy(bc);
        Destroy(cc);
        restartButton.gameObject.SetActive(true);
        deadEndText.color = Color.red;
        deadEndText.text = "You Died";
    }
}
