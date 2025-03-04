using UnityEngine;
using UnityEngine.UI;

public class PointHandler : MonoBehaviour
{
    //the only variables we need
    public float playerPoints = 0.0f;
    [SerializeField] private Text pointText;
    public AudioClip pointPickupAudio;
    private AudioSource playerAudioSource;

    public void Start()
    {
        playerAudioSource = GetComponent<AudioSource>();
    }


    //new function to update points after being passed float: points
    public void updatePoints(float points)
    {
        playerAudioSource.PlayOneShot(pointPickupAudio);

        playerPoints += points;
        pointText.text = "Points: " + playerPoints;
        
    }    
}
