using UnityEngine;
using UnityEngine.UI;

public class GunFunctionality : MonoBehaviour
{
    //bullets
    /*Implementing the gun as full auto using rechambering speed*/
    [SerializeField] private int bulletCountInMagazine = 40;
    [SerializeField] private Text strMagazine;
    [SerializeField] private Text strReserves;
    private bool reloading = false;
    private bool debug = false;

    public float reloadT = 3.0f, bulletsRechamberingSpeed = 0.5f, cRechamber = 0.0f;
    public float reloadTimeR = 0.0f;
    public int reserveRounds = 160;
    public int magazineMax = 40;
    public GameObject bulletType;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        strMagazine.text = bulletCountInMagazine.ToString();
        strReserves.text = reserveRounds.ToString();
        //calls the UIManager script/class to update our reload bar
        UIManager.instance.UpdateReloadBar(this);
    }

    // Update is called once per frame
    void Update()
    {
        if (cRechamber <= bulletsRechamberingSpeed)
        {
            cRechamber += Time.deltaTime;
        }
        //checks if the firebutton has been clicked this frame AND if the bullets in the magazine are above 0
        if ((Input.GetButton("Fire1") == true) && (bulletCountInMagazine > 0) && (cRechamber >= bulletsRechamberingSpeed))
        {

            //creates a new instance of the bullet type assigned to the script
            Instantiate(bulletType, transform.position, transform.rotation);
            //takes away a single bullet after firing
            bulletCountInMagazine -= 1;
            //updates the bullet count on sreen
            strMagazine.text = bulletCountInMagazine.ToString();
            strReserves.text = reserveRounds.ToString();
            cRechamber = 0.0f;


        }
        //if the gun is empty, and the reload timer is less than the full reload time, reload.
        else if (bulletCountInMagazine == 0 && (reserveRounds >= 0))
        {

            reload();

        }
        else if ((bulletCountInMagazine >= 0) && (bulletCountInMagazine < 40) && (Input.GetButton("Reload") == true) && reserveRounds >= 0 || reloading == true)
        {
            if (debug == true)
            {
                Debug.Log("Reloading");
            }
            reloading = true;
            reload();
        }
        //checks if out of bullets
        //checks if reserve rounds are 0 AND the current magazine count is 0
        else if (reserveRounds == 0 && (bulletCountInMagazine == 0))
        {
            /*for future: make this flash red!*/
            strMagazine.text = "No reserves!";

        }

    }
    //new function called refillBullets that refills bullets according to the bullets argument
    public void refillBullets(int bullets)
    {
        reserveRounds += bullets;
        strMagazine.text = bulletCountInMagazine.ToString();
        strReserves.text = reserveRounds.ToString();
    }

    public void reload()
    {
        //Ticks the reload timer for the reload time
        reloadTimeR += Time.deltaTime;
        UIManager.instance.UpdateReloadBar(this);


        if (reloadT <= reloadTimeR)
        { 
            //adds the bullets from the outgoing mag to reserves
            reserveRounds += bulletCountInMagazine;
            //fills the magazine to full (magazineMax variable)
            
            
            bulletCountInMagazine = magazineMax;
            
            
            
                
            
            //removes the amount of bullets from the fresh mag from reserves
            reserveRounds -= bulletCountInMagazine;
           
            //reset the reload timer
            reloadTimeR = 0.0f;
            reloading = false;

            //updates the bullet count on screen
            strMagazine.text = bulletCountInMagazine.ToString();
            strReserves.text = reserveRounds.ToString();
            //calls the UIManager script/class to update our reload bar
            UIManager.instance.UpdateReloadBar(this);


        }

    }
}
