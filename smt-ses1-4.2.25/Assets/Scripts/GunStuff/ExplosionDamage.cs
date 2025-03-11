using UnityEngine;
using UnityEngine.UIElements;

public class ExplosionDamage : MonoBehaviour
{
    private float damage = 100.0f, explodeSize = 60.0f, explosionTimer = 0.3f;
    private Vector3 eScale = new Vector3(1, 1, 1);


    private void Update()
    {

        eScale.x += explodeSize * Time.deltaTime;
        eScale.y += explodeSize * Time.deltaTime;
        eScale.z += explodeSize * Time.deltaTime;

        this.transform.localScale = eScale;

        explosionTimer -= Time.deltaTime;
        if (explosionTimer <= 0)
        {
            Object.Destroy(transform.parent.gameObject);
            
        }


    }
    
    public void OnCollisionEnter(Collision other)
    {
        Debug.Log("i hit something");
        //runs if the other object has the player tag
        if (other.gameObject.tag == "Player")
        {
            //references the colliding object's -> gameobject -> grab a specific component -> runs damage function after finding it
            other.gameObject.GetComponent<PlayerHealth>().PlayerTakeDamage(damage/2);   
        }

        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<EnemyHealthScript>().EnemyTakeDamage(damage);
        }
    }
}
