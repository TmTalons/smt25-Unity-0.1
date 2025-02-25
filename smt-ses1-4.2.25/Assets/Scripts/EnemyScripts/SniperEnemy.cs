using UnityEngine;

public class SniperEnemy : MonoBehaviour
{
    [SerializeField] private bool debug = false;
    [SerializeField] private float mySpeed = 2.0f, attackSpeed = 5.0f, attackTimer = 0.0f;
    [SerializeField] private GameObject thePlayer;
    [SerializeField] private GameObject bulletType;
    [SerializeField] private GameObject myGun;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        thePlayer = GameObject.Find("PlayerModel");
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(thePlayer.transform);

        if ((Vector3.Distance(transform.position, thePlayer.transform.position) > 13.0f))
        {
            transform.position = Vector3.MoveTowards(transform.position, thePlayer.transform.position, (mySpeed * Time.deltaTime));
        }
        
        

        //attack pattern
        if ((Vector3.Distance(transform.position, thePlayer.transform.position) < 13.0f) && attackTimer > attackSpeed)
        {
            //debug statement for dev use
            if (debug == true)
            {
                Debug.Log("Attacking player!");
            }
            //gets the players component named player health to then call the player damage function
            Instantiate(bulletType, myGun.transform.position, transform.rotation);
            //resets our attack timer, so the enemy cannot attack too many times a second
            attackTimer = 0.0f;

        }
        //ticks our timer up by time.deltatime (the time between frames) when we cant attack
        else
        {
            if (attackTimer <= attackSpeed)
            {
                attackTimer += Time.deltaTime;
            }
        }

    }
}
