using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float playerMaxHealth = 100.0f, playerCurrentHealth = 0.0f;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerCurrentHealth = playerMaxHealth;
        //update the ui once
        UIManager.instance.UpdateHealth(this);
    }

    public void TakeDamage(float damage)
    {
        playerCurrentHealth -= damage;

        if (playerCurrentHealth <= 0)
        {
            Debug.Log("Player has died!");

            GetComponent<PlayerController>().enabled = false;
            
        }

        UIManager.instance.UpdateHealth(this);
    }

    public void Heal(float healing)
    {
        playerCurrentHealth += healing;

        if (playerCurrentHealth >= playerMaxHealth)
        {
            playerCurrentHealth = playerMaxHealth;
        }
        UIManager.instance.UpdateHealth(this);
    }
}
