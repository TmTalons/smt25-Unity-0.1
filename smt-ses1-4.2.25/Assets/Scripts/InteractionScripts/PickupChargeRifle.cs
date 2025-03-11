using UnityEngine;

public class PickupChargeRifle : GunPickup
{
    [SerializeField] private GameObject newBulletType, playersGun;

    private int newBulletCount = 1, newReserveRounds = 5, newMagazineMax = 1;
    private float newReloadTime = 2.5f, newRechamberSpeed = 2.0f, newMaxCharge = 2.5f;
    private string newGunName = "Charge Rifle";
    private string firingConfiguration = "Charge";
    public void Start()
    {
        //get the gun functionality object
        playersGun = GameObject.Find("GunHandler");
    }
    public void RayHit()
    {




        //new bullet type to laser
        playersGun.GetComponent<GunFunctionality>().bulletType = newBulletType;
        playersGun.GetComponent<GunFunctionality>().firingConfig = firingConfiguration;


        //new magazine size to 1
        playersGun.GetComponent<GunFunctionality>().bulletCountInMagazine = newBulletCount;
        playersGun.GetComponent<GunFunctionality>().reserveRounds = newReserveRounds;
        playersGun.GetComponent<GunFunctionality>().magazineMax = newMagazineMax;
        playersGun.GetComponent<GunFunctionality>().maxCharge = newMaxCharge;




        //reload timer
        playersGun.GetComponent<GunFunctionality>().reloadT = newReloadTime;
        playersGun.GetComponent<GunFunctionality>().bulletsRechamberingSpeed = newRechamberSpeed;
        //change gun type string
        playersGun.GetComponent<GunFunctionality>().gunType = newGunName;


    }
}
