using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    private bool isAlive = true;
    public float speed = 2.5f;
    private Rigidbody2D rb;
    private SpriteRenderer enemyRenderer;
    private bool onRight;
    public PlayerController player;
    public GameObject enemy;
    private BoxCollider2D bc;
    private CircleCollider2D cc;
    public Text grazText;

    // Start is called before the first frame update
    void Awake ()
    {
        bc = GetComponent<BoxCollider2D>();
        cc = GetComponent<CircleCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        enemyRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isAlive || !player.isAlive)
        {
            return;
        }

        enemyRenderer.flipX = onRight;
        if (gameObject.transform.position.x < player.transform.position.x)
        {
            onRight = true;
        }
        else if (gameObject.transform.position.x > player.transform.position.x)
        {
            onRight = false;
        }

        if (onRight)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
        }
    }

    public void Die ()
    {
        Color temp = grazText.color;
        temp.a = 1f;
        grazText.color = temp;
        rb.velocity = new Vector2(0, rb.velocity.y);
        isAlive = false;
        rb.AddForce(Vector2.up * 200);
        Destroy(bc);
        Destroy(cc);
        Debug.Log("enemy killed");
    }
}
