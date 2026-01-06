using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    public float height = 20f;    // tinggi background, isi manual dari inspector
    public float scrollSpeed = -2f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (rb == null)
        {
            rb = gameObject.AddComponent<Rigidbody2D>();
        }

        rb.gravityScale = 0;
        rb.linearVelocity = new Vector2(0, scrollSpeed);
    }

    void Update()
    {
        if (transform.position.y < -height)
        {
            Vector2 resetPosition = new Vector2(
                transform.position.x,
                transform.position.y + 2 * height
            );
            transform.position = resetPosition;
        }
    }
}
