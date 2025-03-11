using UnityEngine;

public class GrenadeScript : MonoBehaviour
{
    private float fuse = 1.0f, speed = 20.0f, gravPull = -4.0f;
    [SerializeField]private GameObject myExplosion;

    // Update is called once per frame
    void Update()
    {

        gravPull += Time.deltaTime * 8.0f;

        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        transform.Translate(Vector3.down * Time.deltaTime * gravPull);

        if (fuse > 0)
        {
            fuse -= Time.deltaTime;
            if (fuse <= 0)
            {
                myExplosion.SetActive(true);
            }
        }       
    }
}
