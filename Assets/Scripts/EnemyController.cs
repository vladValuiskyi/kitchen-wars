using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb;
    private SpriteRenderer enemy;
    private bool onRight;
    public GameObject player;

    // Start is called before the first frame update
    void Awake ()
    {
        rb = GetComponent<Rigidbody2D>();
        enemy = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        enemy.flipX = onRight;
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
}
