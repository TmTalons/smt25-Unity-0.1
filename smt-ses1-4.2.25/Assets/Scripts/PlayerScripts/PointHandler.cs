using UnityEngine;
using UnityEngine.UI;

public class PointHandler : MonoBehaviour
{
    //the only variables we need
    public float playerPoints = 0.0f;
    [SerializeField] private Text pointText;


    //new function to update points after being passed float: points
    public void updatePoints(float points)
    { 
        playerPoints += points;
        pointText.text = "Points: " + playerPoints;
        
    }    
}
