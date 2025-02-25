using UnityEngine;

public class OrbScript : MonoBehaviour
{

    [SerializeField] private GameObject thePlayer;
    [SerializeField] private bool moveToPlayer = false;
    [SerializeField] private float mySpeed = 6.0f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        thePlayer = GameObject.Find("PlayerModel");

    }

    // Update is called once per frame
    void Update()
    {
        //we can be less optimised with our code because the object shouldn't really exist for too long
        if (Vector3.Distance(transform.position, thePlayer.transform.position) < 8.0f)
        { 
            moveToPlayer = true;
        }

        if (moveToPlayer == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, thePlayer.transform.position, (mySpeed * Time.deltaTime));
        }
    }
}
