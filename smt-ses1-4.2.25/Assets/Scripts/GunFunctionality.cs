using UnityEngine;
using UnityEngine.UI;

public class GunFunctionality : MonoBehaviour
{
    //bullets
    /*Implementing the gun as full auto using rechambering speed*/
    [SerializeField] private int bulletCountInMagazine = 40;
    [SerializeField] private Text strMagazine;
    
    public float reloadT = 3.0f; /*bulletsRechamberingSpeed = 0.1f,*/
    public float reloadTimeR = 0.0f;
    public int reserveRounds = 160;
    public GameObject bulletType;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        strMagazine.text = bulletCountInMagazine.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        //checks if the firebutton has been clicked this frame AND if the bullets in the magazine are above 0
        if (Input.GetButtonDown("Fire1") == true && bulletCountInMagazine > 0)
        {

            //creates a new instance of the bullet type assigned to the script
            Instantiate(bulletType, transform.position, transform.rotation);
            //takes away a single bullet after firing
            bulletCountInMagazine -= 1;
            //updates the bullet count on sreen
            strMagazine.text = bulletCountInMagazine.ToString();

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
                UIManager.instance.UpdateReloadBar(this);


            }
        }
        //checks if out of bullets
        else if (reserveRounds == 0 && bulletCountInMagazine == 0)
        {
            //for future: make this flash red!
            strMagazine.text = "No reserves!";
             
        }

    }

    public void refillBullets(int bullets)
    {
        reserveRounds += bullets;
    }
}
