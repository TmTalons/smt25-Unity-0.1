using UnityEngine;

public class EnemyHealthScript : MonoBehaviour
{
    public float myEnemyHealth = 50.0f;
    [SerializeField] private GameObject healthOrb;
    [SerializeField] private GameObject ammoOrb;
    [SerializeField] private GameObject pointOrb;
    [SerializeField] private GameObject healthBar;
    [SerializeField] private float maximumHealth;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        maximumHealth = myEnemyHealth;
    }

    public void EnemyTakeDamage(float damage)
    { 
        myEnemyHealth -= damage;

        healthBar.transform.localScale = new Vector3(0.25f * (myEnemyHealth/maximumHealth) , 0.1f, 0.025f);

        if (myEnemyHealth <= 0)
        {
            for (int i = 0; i <= Random.Range(0, 2); i++)
            {
                Instantiate(healthOrb, Random.insideUnitSphere * 1 + transform.position, Random.rotation);
            }

            for (int i = 0; i <= Random.Range(0, 2); i++)
            {
                Instantiate(ammoOrb, Random.insideUnitSphere * 1 + transform.position, Random.rotation);
            }

            for (int i = 0; i <= Random.Range(0, 2); i++)
            {
                Instantiate(pointOrb, Random.insideUnitSphere * 1 + transform.position, Random.rotation);
            }
            



            Object.Destroy(this.gameObject);
        }
    }
}
