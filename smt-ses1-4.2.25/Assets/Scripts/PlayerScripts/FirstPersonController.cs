using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonController : MonoBehaviour
{
    public float speed = 2.0f;
    //public float sprintSpeed = 5.0f;
    public float gravity = 2.4f;
    public float jumpForce = 0.08f;
    public float gravPull = 8.0f;

    private float currentSpeed = 0;
    [SerializeField]private float velocity = 0;
    private CharacterController controller;
    private Vector3 motion;

    [SerializeField] private Camera mainCamera;
    

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    // Start is called before the first frame update
    void Start()
    {
        currentSpeed = speed;

        InvokeRepeating("movementScript", 0.0f, 0.005f);

    }

    
    void Update()
    {
        
    }

    void ApplyMovement()
    {
        motion += transform.forward * Input.GetAxisRaw("Vertical") * currentSpeed;
        motion += transform.right * Input.GetAxisRaw("Horizontal") * currentSpeed;
        motion.y += velocity;
        controller.Move(motion);
    }

    void movementScript()
    {
        motion = Vector3.zero;

        if (Input.GetButton("Interact"))
        {
            mainCamera.GetComponent<PlayerInteractionScript>().InteractionRay();

        }

        if (controller.isGrounded == true)
        {
            velocity = -gravity;

            if (Input.GetKey(KeyCode.Space) == true)
            {
                velocity = jumpForce;
            }
            /*else if (Input.GetKeyDown(KeyCode.LeftShift) == true)
            {
                //check to see speed is not equal to sprint speed
                if (currentSpeed != sprintSpeed)
                {
                    currentSpeed = sprintSpeed;
                }
            }*/
            else if (Input.GetKeyUp(KeyCode.LeftShift) == true)
            {
                //change to walk speed
                if (currentSpeed != speed)
                {
                    currentSpeed = speed;
                }
            }
        }
        else
        {
            velocity -= (gravity) / gravPull;
            Debug.Log(velocity);
        }
        ApplyMovement();
    }
}

