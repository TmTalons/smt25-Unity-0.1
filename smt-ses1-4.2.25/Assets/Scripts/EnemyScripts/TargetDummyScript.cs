using UnityEngine;

public class TargetDummyScript : MonoBehaviour
{
    private GameObject playerTarget;
    private float damage = -500;
    private float time = 0;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerTarget = GameObject.Find("PlayerModel");
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        
        transform.LookAt(playerTarget.transform);
        if (time >= 5 && this.gameObject.GetComponent<EnemyHealthScript>().myEnemyHealth < 400)
        { 
            time = 0;
            this.gameObject.GetComponent<EnemyHealthScript>().EnemyTakeDamage(damage);
        }
    }
}
