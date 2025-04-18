using UnityEngine;
using UnityEngine.UI;

public class PickupGL : GunPickup
{

    [SerializeField] private GameObject newBulletType, playersGun;

    private int newBulletCount = 4, newReserveRounds = 12, newMagazineMax = 4;
    private float newReloadTime = 4.0f, newRechamberSpeed= 1.5f;
    private string newGunName = "Grenade Launcher";
    private string firingConfiguration = "Automatic";



    public void Start()
    {
        //get the gun functionality object
        playersGun = GameObject.Find("GunHandler");
    }


    public void RayHit()
    {
        



        //new bullet type to grenade
        playersGun.GetComponent<GunFunctionality>().bulletType = newBulletType;
        playersGun.GetComponent<GunFunctionality>().firingConfig = firingConfiguration;


        //new magazine size to 6
        playersGun.GetComponent<GunFunctionality>().bulletCountInMagazine = newBulletCount;
        playersGun.GetComponent<GunFunctionality>().reserveRounds = newReserveRounds;
        playersGun.GetComponent<GunFunctionality>().magazineMax = newMagazineMax;




        //reload timer
        playersGun.GetComponent<GunFunctionality>().reloadT = newReloadTime;
        playersGun.GetComponent<GunFunctionality>().bulletsRechamberingSpeed = newRechamberSpeed;
        //change gun type string
        playersGun.GetComponent<GunFunctionality>().gunType = newGunName;


    }
}
