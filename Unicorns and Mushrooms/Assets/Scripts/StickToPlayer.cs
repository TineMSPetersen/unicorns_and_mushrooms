using UnityEngine;

public class Attraction2D : MonoBehaviour
{
    public Transform stationaryObject;
    public float attractionForce = 10f;
    public float attractionRange = 2f;
    public float stickinessForce = 20f;

    private Rigidbody2D rb;
    private bool isStuck = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (!isStuck)
        {
            Vector2 direction = stationaryObject.position - transform.position;

            float distance = direction.magnitude;
            float forceMagnitude = (1 / distance) * attractionForce;

            direction.Normalize();
            rb.AddForce(direction * forceMagnitude);

            if (distance <= attractionRange)
            {
                isStuck = true;
                rb.velocity = Vector2.zero;
                rb.AddForce(direction * stickinessForce, ForceMode2D.Impulse);

                rb.gravityScale = 0f;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform == stationaryObject)
        {
            isStuck = true;
            rb.gravityScale = 0f;
            rb.velocity = Vector2.zero;

            Vector2 direction = stationaryObject.position - transform.position;
            direction.Normalize();
            rb.AddForce(direction * stickinessForce, ForceMode2D.Impulse);
        }
    }
}


