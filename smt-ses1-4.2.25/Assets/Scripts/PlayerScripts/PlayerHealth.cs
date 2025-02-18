using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float playerMaxHealth = 100.0f, playerCurrentHealth = 0.0f, damageGate = 1.0f, damageGateTimer = 0.0f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerCurrentHealth = playerMaxHealth;
        //update the ui once
        UIManager.instance.UpdateHealth(this);
    }

    private void Update()
    {
        if (damageGateTimer < damageGate)
        {
            damageGateTimer += Time.deltaTime;
        }
    }

    public void PlayerTakeDamage(float damage)
    {
        if (damageGateTimer >= damageGate)
        {
            playerCurrentHealth -= damage;
            damageGateTimer = 0.0f;

            if (playerCurrentHealth <= 0)
            {
                Debug.Log("Player has died!");
                UIManager.instance.UpdateHealth(this);

                GetComponent<FirstPersonController>().enabled = false;

            }

            UIManager.instance.UpdateHealth(this);
        }
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
