using UnityEngine;

public class Disabilities : MonoBehaviour
{
    public GameObject CardOverlay;

    void Start()
    {
        CardOverlay.SetActive(false);
}

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (CardOverlay != null)
            {
                CardOverlay.SetActive(true);
            }
        }
    }
}