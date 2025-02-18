using UnityEngine;

public class EnemyHealthScript : MonoBehaviour
{
    public float myEnemyHealth = 50.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void EnemyTakeDamage(float damage)
    { 
        myEnemyHealth -= damage;

        if (myEnemyHealth <= 0)
        {
            Object.Destroy(this.gameObject);
        }
    }
}
