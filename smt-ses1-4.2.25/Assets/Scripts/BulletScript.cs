using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField]private float bulletSpeed = 50.0f, maxInstanceTime = 2.5f, instanceTimer = 0.0f;
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
        Object.Destroy(this.gameObject);
    }
}
