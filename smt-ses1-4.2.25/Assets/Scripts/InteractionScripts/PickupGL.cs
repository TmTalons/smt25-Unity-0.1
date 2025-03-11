using Unity.VisualScripting;
using UnityEngine;

public class PickupGL : GunPickup
{

    [SerializeField] private GameObject newBulletType, playersGun;

    private int newBulletCount = 4, newReserveRounds = 12, newMagazineMax = 4;
    private float newReloadTime = 4.0f, newRechamberSpeed= 1.5f;
    private string newGunName = "Grenade Launcher";



    public void Start()
    {
        //get the gun functionality object
        playersGun = GameObject.Find("GunHandler");
    }


    public void RayHit()
    {
        Debug.Log("An interaction was made.");



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
