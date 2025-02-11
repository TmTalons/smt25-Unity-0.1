using UnityEngine;

public class GunFunctionality : MonoBehaviour
{
    //bullets
    /*Implementing the gun as full auto using rechambering speed*/
    [SerializeField] private int bulletCountInMagazine = 40, reserveRounds = 160;
    [SerializeField] private float reloadT = 3.0f, /*bulletsRechamberingSpeed = 0.1f,*/ reloadTimeR = 0.0f;

    public GameObject bulletType;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //check if gun is empty?
    }

    // Update is called once per frame
    void Update()
    {
        //checks if the firebutton has been clicked this frame AND if the bullets in the magazine are above 0
        if (Input.GetButtonDown("Fire1") == true && bulletCountInMagazine > 0)
        {

            //creates a new instance of the bullet type assigned to the script
            Instantiate(bulletType);
            //takes away a single bullet after firing
            bulletCountInMagazine -= 1;
        }
        //if the gun is empty, and the reload timer is less than the full reload time, reload.
        else if (bulletCountInMagazine == 0 && reloadT != reloadTimeR)
        {
            //Ticks the reload timer for the reload time
            reloadTimeR += Time.deltaTime;
            if (reloadT <= reloadTimeR)
            {
                //fills the magazine to full (40 rounds)
                bulletCountInMagazine = 40;
                //then removes the amount of rounds in the gun from reserves
                reserveRounds -= bulletCountInMagazine;
                //reset the reload timer
                reloadTimeR = 0.0f;
            }
        }
        

    }
}
