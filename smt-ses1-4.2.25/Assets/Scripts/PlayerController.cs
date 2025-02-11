using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 2.0f, sprintSpeed = 5.0f, gravity = 3.5f, jumpForce = 5.0f;
    private float currentSpeed = 0, velocity = 0;
    private CharacterController controller;
    [SerializeField] private Vector3 motion;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Start()
    {
        currentSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {

        motion = Vector3.zero;

        //ground check
        if (controller.isGrounded == true)
        {
            
            velocity = -gravity * Time.deltaTime;

            if (Input.GetKeyDown(KeyCode.LeftShift) == true)
            {
                if (currentSpeed != sprintSpeed)
                {
                    currentSpeed = sprintSpeed;
                }
            }
            else if (Input.GetKeyUp(KeyCode.LeftShift) == true)
            {
                if (currentSpeed != speed)
                {
                    currentSpeed = speed;
                }
            }
            //personal code adaption for fun

            if (Input.GetKeyDown(KeyCode.Space) == true)
            {
                motion.y = jumpForce;
            }
            

        }
        
        
        else
        {
            
            velocity -= gravity * Time.deltaTime;
        }

        ApplyMovement();
    }

    void ApplyMovement()
    {
        motion += transform.forward * Input.GetAxisRaw("Vertical") * currentSpeed * Time.deltaTime;
        motion += transform.right * Input.GetAxisRaw("Horizontal") * currentSpeed * Time.deltaTime;
        motion.y += velocity;

        if (controller.enabled)
        {
            controller.Move(motion);
        }
    }
}
