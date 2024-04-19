using UnityEngine;

public class StickToPlayer : MonoBehaviour
{
    public Transform stationaryObject;
    public float attractionForce = 10f;
    public float attractionRange = 2f;
    public float stickinessForce = 20f;

    private Rigidbody2D rb;
    private bool isSticked = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (!isSticked)
        {
            Vector2 direction = stationaryObject.position - transform.position;

            float distance = direction.magnitude;
            float forceMagnitude = (1 / distance) * attractionForce;

            direction.Normalize();
            rb.AddForce(direction * forceMagnitude);

            if (distance <= attractionRange)
            {
                isSticked = true;
                rb.velocity = Vector2.zero;
                rb.gravityScale = 0f;
            }
        }
        else // this keeps it sticked
        {
            Vector2 direction = stationaryObject.position - transform.position;
            rb.AddForce(direction * stickinessForce * Time.fixedDeltaTime, ForceMode2D.Force);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform == stationaryObject)
        {
            isSticked = true;
            rb.velocity = Vector2.zero;
            rb.gravityScale = 0f;
        }
    }
}



