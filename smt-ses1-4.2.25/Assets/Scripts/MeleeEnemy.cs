using Unity.VisualScripting;
using UnityEngine;

public class MeleeEnemy : MonoBehaviour
{
    //our variable list
    [SerializeField] private bool debug = false;
    [SerializeField] private Transform playerTarget;
    [SerializeField] private float mySpeed = 1.0f, attackSpeed = 2.0f, attackTimer = 0.0f;
    [SerializeField] private float damage = 10;
    [SerializeField] private float myHealth = 50;
    [SerializeField] private GameObject thePlayer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        /*
        When an object is dragged into the editor, or when we first instantiate an object, even if we drag over
        what things we want to reference before turning the object into a prefab, it forgets all of it when a new
        instance is made. Therefore, with these lines, we identify the player and its transform and assigns them
        to a pair of variables.
         */
        thePlayer = GameObject.Find("PlayerModel");
        playerTarget = thePlayer.transform;
    }

    // Update is called once per frame
    void Update()
    {
        //the position of this script object/class is equal to a the vector3's movetowards function
        //the arguments it takes are current position, the target's position, then the speed it should move towards the target
        transform.position = Vector3.MoveTowards(transform.position, playerTarget.position, (mySpeed * Time.deltaTime));
        
        //we make an attack when our attack timer is greater than our attack speed variable, AND when we are close enough
        if ((Vector3.Distance(transform.position, playerTarget.position) < 3.0f) && attackTimer > attackSpeed)
        {
            //debug statement for dev use
            if (debug == true) 
            {
                Debug.Log("Attacking player!");
            }
            //gets the players component named player health to then call the player damage function
            thePlayer.GetComponent<PlayerHealth>().PlayerTakeDamage(damage);
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
