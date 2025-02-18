using UnityEngine;

public class HealthPack : MonoBehaviour
{
    public float healing = 5.0f;
    [SerializeField] bool destroyOnInteract = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<PlayerHealth>().Heal(healing);
            if (destroyOnInteract == true)
            {
                Destroy(gameObject);
            }
        }
    }
}
