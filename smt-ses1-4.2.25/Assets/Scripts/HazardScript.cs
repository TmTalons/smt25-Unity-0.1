using UnityEngine;

public class HazardScript : MonoBehaviour
{
    public float damage = 10.0f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Dealt " + damage + " to player.");
            other.GetComponent<PlayerHealth>().TakeDamage(damage);
        }
    }
}
