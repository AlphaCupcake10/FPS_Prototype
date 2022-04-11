using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    public LayerMask Ground;
    public Transform FPSCam;
    public float Sensitivity = 2,MovementSpeed = 0,JumpForce = 1,JumpThrust=1;
    public int MaxJumps = 2;
    int CurrentJumps = 0;
    float YRot = 0,XRot;
    Rigidbody RB;

    
    Vector2 InputLookAxis = Vector2.zero;
    Vector2 InputMovementAxis = Vector2.zero;
    bool HasPressedJump = false;

    void MyInput()
    {
        InputLookAxis.x = Input.GetAxisRaw("Mouse X");
        InputLookAxis.y = Input.GetAxisRaw("Mouse Y");
        InputMovementAxis.x = Input.GetAxisRaw("Horizontal");
        InputMovementAxis.y = Input.GetAxisRaw("Vertical");
        HasPressedJump = Input.GetButton("Jump");
    }
    void Start()
    {
        RB = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        MyInput();
        Rotate();
    }

    void FixedUpdate()
    {
        Move();    
    }
    
    void Rotate()
    {
        transform.rotation = Quaternion.AngleAxis(YRot,transform.up);
        YRot += InputLookAxis.x * Sensitivity;
        FPSCam.localRotation = Quaternion.AngleAxis(XRot,Vector3.right);
        XRot -= InputLookAxis.y * Sensitivity;
        if(XRot>90)XRot = 90;
        if(XRot<-90)XRot = -90;
    }

    void Move()
    {

        bool TG = IsGrounded();
        Vector2 Mov = InputMovementAxis.normalized * MovementSpeed * 0.065f;
        if(Input.GetKey(KeyCode.LeftShift))Mov *= 1.75f;
        
        if(TG)
        {
            RB.AddForce((transform.right * Mov.x + transform.forward*Mov.y)* .3f * 35,ForceMode.VelocityChange);
            RB.velocity = new Vector3(RB.velocity.x * 0.9f,RB.velocity.y,RB.velocity.z * 0.9f);
        }
        
        
        
        JumpTimer += Time.fixedDeltaTime;
        if(HasPressedJump)
        {
            if(JumpTimer < 0.5f)return;
            if(TG)
            {
                Jump();
            }
            else if(CurrentJumps < MaxJumps || MaxJumps == 0)
            {
                if(InputMovementAxis != Vector2.zero)
                {
                    RB.velocity = new Vector3(RB.velocity.x ,RB.velocity.y,RB.velocity.z) * 0.15f * JumpThrust;
                    RB.AddForce((transform.right * Mov.x + transform.forward*Mov.y)* 4000,ForceMode.Impulse);
                }
                Jump();
            }
        }
    }
    float JumpTimer = 0;
    void Jump()
    {
        JumpTimer = 0;
        CurrentJumps += 1;
        RB.velocity = new Vector3(RB.velocity.x,JumpForce *10,RB.velocity.z);
    }
    bool IsGrounded()
    {
        if(Physics.CheckSphere(transform.position,.1f,Ground))
        {
            CurrentJumps = 0;
            return true;
        }
        else
            return false;
    }
}
