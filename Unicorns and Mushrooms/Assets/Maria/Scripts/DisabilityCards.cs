using UnityEngine;

public class DisabilityCards : MonoBehaviour
{
    public GameObject DisabilityCard;

    void Start()
    {
        DisabilityCard.SetActive(true);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (DisabilityCard != null)
            {
                DisabilityCard.SetActive(false);
            }

        }
    }
}
