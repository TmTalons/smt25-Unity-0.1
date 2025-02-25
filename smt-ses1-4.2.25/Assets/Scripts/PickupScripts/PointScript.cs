using UnityEngine;

public class PointScript : MonoBehaviour
{
    public int points = 5;
    [SerializeField] private bool destroyOnPickup = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponentInChildren<PointHandler>().updatePoints(points);
            if (destroyOnPickup == true)
            {
                Destroy(gameObject);
            }
        }
    }
}
