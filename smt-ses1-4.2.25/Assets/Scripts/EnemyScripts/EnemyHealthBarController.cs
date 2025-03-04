using UnityEngine;

public class EnemyHealthBarController : MonoBehaviour
{
    [SerializeField] private GameObject healthBar;

    public void EnemyUpdateHealth(PlayerHealth health)
    {
        transform.localScale = new Vector3(3, 0,0); 

    }
}
