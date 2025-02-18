using UnityEngine;

public class EnemySpawnScript : MonoBehaviour
{
    [SerializeField] private GameObject enemyToSpawnPrefab;
    [SerializeField] private float spawnTimer = 0.0f;
    [SerializeField] private float spawnDelay = 10.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer += Time.deltaTime;

        if (spawnTimer >= spawnDelay)
        { 
            Instantiate(enemyToSpawnPrefab, transform.position, transform.rotation);
            spawnTimer = 0.0f;
        }


    }
}
