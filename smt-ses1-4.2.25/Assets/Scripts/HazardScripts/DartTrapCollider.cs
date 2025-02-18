using UnityEngine;

public class DartTrapCollider : MonoBehaviour
{
    [SerializeField] private GameObject MyDartSpawner;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        { 
            MyDartSpawner.GetComponent<DartSpawnerScript>().SpawnDart();
        }
    }
}
