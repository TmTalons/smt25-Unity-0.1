using UnityEngine;
using UnityEngine.InputSystem.Controls;

public class BulletScript : MonoBehaviour
{
    [SerializeField] private float bulletSpeed = 50.0f, maxInstanceTime = 2.5f, instanceTimer = 0.0f;
    [SerializeField] private int damage = 25;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * bulletSpeed);
        if (instanceTimer < maxInstanceTime)
        {
            instanceTimer += Time.deltaTime;
        }
        else 
        { 
            Object.Destroy(this.gameObject);
        }

        

    }

    void OnCollisionEnter(Collision other)
    {
        //when the object hits another object, destroy this object
        Debug.Log("Collided with " + other.gameObject.name);
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerHealth>().PlayerTakeDamage(damage);
            Object.Destroy(this.gameObject);
        }
        Object.Destroy(this.gameObject);
        
    }
}
