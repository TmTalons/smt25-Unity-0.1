using System.Diagnostics;
using UnityEngine;

public class LaserScript : MonoBehaviour
{
    private float damage = 150.0f;
    private float lifetime = 0.0f;
   

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnTriggerEnter(UnityEngine.Collider other)
    {
        

        //runs if the other object has the player tag
        if (other.gameObject.tag == "Player")
        {
            //references the colliding object's -> gameobject -> grab a specific component -> runs damage function after finding it
            other.gameObject.GetComponent<PlayerHealth>().PlayerTakeDamage(damage);
        }

        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<EnemyHealthScript>().EnemyTakeDamage(damage);
        }
    }
    private void Update()
    {
        lifetime += Time.deltaTime;
        if (lifetime >= 1)
        { 
            Object.Destroy(this.gameObject);
        }
    }
}
