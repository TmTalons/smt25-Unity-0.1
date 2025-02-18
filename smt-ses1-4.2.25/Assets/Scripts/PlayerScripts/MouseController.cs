using UnityEngine;

public class MouseController : MonoBehaviour
{
    //Declaing variables mouseSensitivity and mouseDrag as floats.
    public float mouseSensitivity = 2.5f, mouseDrag = 1.5f;

    //Declaring private variables 
    [SerializeField] private Transform characterTransform;
    [SerializeField] private Vector2 mouseDirection, smoothing, result;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        characterTransform = transform.root;
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        mouseDirection = new Vector2(Input.GetAxisRaw("Mouse X") * mouseSensitivity, Input.GetAxisRaw("Mouse Y") * mouseSensitivity);
        smoothing = Vector2.Lerp(smoothing, mouseDirection, 1 / mouseDrag);
        result += smoothing;


        //Means the player cant look behind via looking up, looping and confusing the player.
        result.y = Mathf.Clamp(result.y, -89, 89);

        transform.localRotation = Quaternion.AngleAxis(-result.y, Vector3.right);
        characterTransform.rotation = Quaternion.AngleAxis(result.x, characterTransform.up);

        


    }
}
