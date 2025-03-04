using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    //all our variables
    [SerializeField]private bool debug = false;
    public float playerMaxHealth = 100.0f, playerCurrentHealth = 0.0f;
    public AudioClip healAudio, hurtAudio;
    private AudioSource playerAudioSource;
    
    //our damage gate timer
    [SerializeField]private float damageGate = 1.0f, damageGateTimer = 0.0f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerAudioSource = GetComponent<AudioSource>();
        playerCurrentHealth = playerMaxHealth;
        //update the ui once
        UIManager.instance.UpdateHealth(this);
    }

    private void Update()
    {
        //ticks our timer up when the damage gate is active
        if (damageGateTimer >= damageGate)
        {
            damageGateTimer += Time.deltaTime;
        }
    }

    //player health script is referenced, and this function is called whenever the player is supposed to take damage
    public void PlayerTakeDamage(float damage)
    {
        //if our damage gate is active (active for ~1s after we take damage)
        if (damageGateTimer <= damageGate)
        {
            playerCurrentHealth -= damage;

            playerAudioSource.PlayOneShot(hurtAudio);
            /*resets the damage gate timer after getting hit, because we can only take damage after our damage gate time
             is high enough anyway.
             */
            damageGateTimer = 0.0f;

            //checks if our player is equal to or below one, meaning our player has died.
            if (playerCurrentHealth <= 0)
            {
                //debug log for devs
                if (debug == true)
                {
                    Debug.Log("Player has died!");
                }
                //any time this is called, update the health bar.
                UIManager.instance.UpdateHealth(this);
                
                //disables our first person controller
                GetComponent<FirstPersonController>().enabled = false;

            }

            UIManager.instance.UpdateHealth(this);
        }
    }

    //the heal function on our health bar
    public void Heal(float healing)
    {
        //health ticks up by the healing value
        playerCurrentHealth += healing;

        playerAudioSource.PlayOneShot(healAudio);

        //prevents health overflow by setting any overflowed values to our max.
        if (playerCurrentHealth >= playerMaxHealth)
        {
            playerCurrentHealth = playerMaxHealth;
        }
        UIManager.instance.UpdateHealth(this);
    }
}
