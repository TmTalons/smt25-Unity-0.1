using UnityEngine;

public class DartSpawnerScript : MonoBehaviour
{
    public GameObject bulletType;

    public void SpawnDart()
    {
        Debug.Log("Spawning dart...");
        Instantiate(bulletType, transform.position, transform.rotation );
    }
}
