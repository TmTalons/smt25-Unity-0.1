using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonController : MonoBehaviour
{
    public float speed = 2.0f;
    public float sprintSpeed = 5.0f;
    public float gravity = 3.5f;
    public float jumpForce = 0.1f;
    public float gravPull = 8.0f;

    private float currentSpeed = 0;
    private float velocity = 0;
    private CharacterController controller;
    private Vector3 motion;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    // Start is called before the first frame update
    void Start()
    {
        currentSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        motion = Vector3.zero;

        if (controller.isGrounded == true)
        {
            velocity = -gravity * Time.deltaTime;

            if (Input.GetKeyDown(KeyCode.Space) == true)
            {
                velocity = jumpForce;
            }
            else if (Input.GetKeyDown(KeyCode.LeftShift) == true)
            {
                //check to see speed is not equal to sprint speed
                if (currentSpeed != sprintSpeed)
                {
                    currentSpeed = sprintSpeed;
                }
            }
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
            velocity -= (gravity * Time.deltaTime)/gravPull;
        }
        ApplyMovement();
    }

    void ApplyMovement()
    {
        motion += transform.forward * Input.GetAxisRaw("Vertical") * currentSpeed * Time.deltaTime;
        motion += transform.right * Input.GetAxisRaw("Horizontal") * currentSpeed * Time.deltaTime;
        motion.y += velocity;
        controller.Move(motion);
    }
}

