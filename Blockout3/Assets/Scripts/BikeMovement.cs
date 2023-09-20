using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Serialization;
using Vector3 = UnityEngine.Vector3;

public class BikeMovement : MonoBehaviour
{
    [Header("Movement")]
    public float driveSpeed;
    public float slowSpeed;
    public float fastSpeed;
    public float groundDrag;

    [Header("Movement")]
    public float rotSpeedGround;
    public float rotSpeedAir;
    private bool speeding;
    
    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    bool readyToJump;
    
    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;
    public KeyCode sprintKey = KeyCode.LeftShift;


    [Header("Ground Check")]
    public float playerHeight;
    [FormerlySerializedAs("whatIsGround")] public LayerMask whatIsRoad;
    public LayerMask whatIsGrass;
    [SerializeField] bool grounded;

    public Transform orientation;
    public Transform obj;

    [ SerializeField] float horizontalInput;
    [ SerializeField] float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;

    
    
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        readyToJump = true;
    }

    private void Update()
    {
        grounded = Physics.Raycast(transform.position - Vector3.down * playerHeight*0.5f, Vector3.down, playerHeight * 0.5f + 0.3f, whatIsRoad) ||
                   Physics.Raycast(transform.position - Vector3.down * playerHeight*0.5f, Vector3.down, playerHeight * 0.5f + 0.3f, whatIsGrass);

            
        MyInput();
        SpeedControl();
        
        // handle drag
        if (grounded)
            rb.drag = groundDrag;
        else
            rb.drag = 0;

        if (speeding)
        {
            Vector3 moveDir = orientation.forward;
            obj.forward = Vector3.Normalize(
                new Vector3(moveDir.x,
                        (float)(moveDir.y * Math.Cos(45 / 180 * Math.PI) - moveDir.z * Math.Sin(45 / 180 * Math.PI)),
                        (float)(moveDir.y * Math.Sin(45 / 180 * Math.PI) + moveDir.z * Math.Cos(45 / 180 * Math.PI))));

        }

        else
            obj.forward = orientation.forward;

    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        
        

        speeding = Input.GetKey(sprintKey);
        
        // when to jump
        if(Input.GetKey(jumpKey) && readyToJump && grounded)
        {
            readyToJump = false;

            Jump();

            Invoke(nameof(ResetJump), jumpCooldown);
        }
    }

    private void MovePlayer()
    {
        // calculate movement direction
        moveDirection = orientation.forward * verticalInput;
        if (grounded)
            transform.Rotate(Vector3.up * (rotSpeedGround * Time.deltaTime * horizontalInput));
        else
            transform.Rotate(Vector3.up * (rotSpeedAir * Time.deltaTime * horizontalInput));

        if (speeding)
            driveSpeed = fastSpeed;
        else
            driveSpeed = slowSpeed;
        rb.AddForce(moveDirection.normalized * (driveSpeed * 10f), ForceMode.Force);
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        // limit velocity if needed
        if(flatVel.magnitude > driveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * driveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }
    
    private void Jump()
    {
        // reset y velocity
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }
    private void ResetJump()
    {
        readyToJump = true;
    }
}

