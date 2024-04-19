using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D myRigidbody2D;
    public float speed = 5f;
    public GameObject discard;

    void Start()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        if (discard.activeSelf) {
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Translate(Vector3.right * speed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Translate(Vector3.left * speed * Time.deltaTime);
            }

        }

        if (DisabilityCard.SetActive(true))
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Translate(Vector3.left * speed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Translate(Vector3.right * speed * Time.deltaTime);
            }

        }

    }
}
