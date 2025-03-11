using UnityEngine;

public class KillBox : MonoBehaviour
{
    private float damage = 1000.0f;
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerHealth>().PlayerTakeDamage(damage);
        }
    }
}
