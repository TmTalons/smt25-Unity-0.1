using UnityEngine;
using UnityEngine.InputSystem.Controls;

public class BulletScript : MonoBehaviour
{
    [SerializeField] private bool debug = false;
    [SerializeField] private float bulletSpeed = 50.0f, maxInstanceTime = 2.5f, instanceTimer = 0.0f;
    [SerializeField] private int damage = 25;


    // Update is called once per frame
    void Update()
    {
        //takes our transform and moves the bullet forward by a factor of our bullet speed and the time between frames
        transform.Translate(Vector3.forward * Time.deltaTime * bulletSpeed);
        //ticks our timer up by the time between frames if our timer is lower than the maximum
        if (instanceTimer < maxInstanceTime)
        {
            instanceTimer += Time.deltaTime;
        }
        //if the timer goes above the max, destroy itself
        else 
        { 
            Object.Destroy(this.gameObject);
        }

        

    }


    //runs when the bullet hits another thing with a collision.
    void OnCollisionEnter(Collision other)
    {
        //debug statement for devs
        if (debug == true)
        {
            //logs what thing we collided with
            Debug.Log("Collided with " + other.gameObject.name);
        }
        
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

        
        
        //destroys this game object, deleting it from the scene. our bullet shouldnt exist after this runs anyway.
        Object.Destroy(this.gameObject);
        
    }
}
