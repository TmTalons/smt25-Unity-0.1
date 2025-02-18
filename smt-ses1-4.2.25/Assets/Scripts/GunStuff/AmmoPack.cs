using UnityEngine;

public class AmmoPack : MonoBehaviour
{
    public int bullets = 40;
    [SerializeField]private bool destroyOnPickup = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponentInChildren<GunFunctionality>().refillBullets(bullets);
            if (destroyOnPickup == true)
            { 
                Destroy(gameObject);
            }
        }
    }
}
