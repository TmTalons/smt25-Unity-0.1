using UnityEngine;

public class PickupAR : GunPickup
{
    [SerializeField] private GameObject newBulletType, playersGun;

    private int newBulletCount = 30, newReserveRounds = 180, newMagazineMax = 30;
    private float newReloadTime = 2.5f, newRechamberSpeed = 0.35f;
    private string newGunName = "Assault Rifle";



    public void Start()
    {
        //get the gun functionality object
        playersGun = GameObject.Find("GunHandler");
    }


    public void RayHit()
    {




        //new bullet type to grenade
        playersGun.GetComponent<GunFunctionality>().bulletType = newBulletType;


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
