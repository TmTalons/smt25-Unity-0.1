using NUnit.Framework.Constraints;
using UnityEngine;

public class PlayerInteractionScript : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private float interactionDistance = 3.0f;
    [SerializeField] private LayerMask layerMask;

    public void InteractionRay()
    {
       

        Vector3 screenCentre = new Vector3(Screen.width / 2, Screen.height / 2, 0);

        Ray ray = mainCamera.ScreenPointToRay(screenCentre);

        if (Physics.Raycast(ray, interactionDistance, layerMask))
        {
            Debug.Log("I hit something!");
        }
        
    }
}
