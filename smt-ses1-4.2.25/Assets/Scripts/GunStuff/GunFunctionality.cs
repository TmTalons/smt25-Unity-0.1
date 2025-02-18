using UnityEngine;
using UnityEngine.UI;

public class GunFunctionality : MonoBehaviour
{
    //bullets
    /*Implementing the gun as full auto using rechambering speed*/
    [SerializeField] private int bulletCountInMagazine = 40;
    [SerializeField] private Text strMagazine;
    
    public float reloadT = 3.0f, bulletsRechamberingSpeed = 0.5f, cRechamber = 0.0f;
    public float reloadTimeR = 0.0f;
    public int reserveRounds = 160;
    public GameObject bulletType;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        strMagazine.text = bulletCountInMagazine.ToString();
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
            cRechamber = 0.0f;
            

        }
        //if the gun is empty, and the reload timer is less than the full reload time, reload.
        else if (bulletCountInMagazine == 0 && reloadT != reloadTimeR && reserveRounds != 0)
        {
            //Ticks the reload timer for the reload time
            reloadTimeR += Time.deltaTime;
            UIManager.instance.UpdateReloadBar(this);


            if (reloadT <= reloadTimeR)
            {
                //fills the magazine to full (40 rounds)
                bulletCountInMagazine = 40;
                //then removes the amount of rounds in the gun from reserves
                reserveRounds -= bulletCountInMagazine;
                //reset the reload timer
                reloadTimeR = 0.0f;

                //updates the bullet count on screen
                strMagazine.text = bulletCountInMagazine.ToString();
                //calls the UIManager script/class to update our reload bar
                UIManager.instance.UpdateReloadBar(this);


            }
        }
        //checks if out of bullets
        //checks if reserve rounds are 0 AND the current magazine count is 0
        else if (reserveRounds == 0 && bulletCountInMagazine == 0)
        {
            /*for future: make this flash red!*/
            strMagazine.text = "No reserves!";
             
        }

    }
    //new function called refillBullets that refills bullets according to the bullets argument
    public void refillBullets(int bullets)
    {
        reserveRounds += bullets;
    }
}
