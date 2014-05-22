using UnityEngine;
using System.Collections;
using System;

public enum MovementType
{
    Up,
    Down,
    Right,
    Left,
    Jump
}

public class Movement : MonoBehaviour {
    
    public float runSpeed;
    public float walkSpeed;
    public float jumpSpeed;

    private int rotationX = 0;
    private int rotationY = 0;

    private bool isGrounded = false;
    private bool isRunning = false;

    void Start()
    {
        Rotate();
    }

    public bool IsRunning
    {
        get { return isRunning; }
        set { this.isRunning = value; }
    }

    public bool IsGrounded
    {
        get { return isGrounded; }
    }

    public float MoveSpeed
    {

        get { return (isRunning ? runSpeed : walkSpeed); }
    }

    public void Move(float x)
    {
        if (x < 0) { rotationY = 180; }
        else if(x > 0) { rotationY = 0; }

        Rotate();

        transform.Translate(Vector2.right * MoveSpeed /* Math.Abs(x)*/ * Time.deltaTime);
    }

    public void Move(MovementType type)
    {
        switch (type)
        {

            //does nothing for now, some contextual actions can be implemented
            case MovementType.Up:
                //transform.Translate(-1*Vector2.up * speed * Time.deltaTime);
                break;

            //does nothing for now, some contextual actions can be implemented
            case MovementType.Down:
                //transform.Translate(-1*Vector2.up * speed * Time.deltaTime);
                break;

            case MovementType.Right:
                transform.Translate(Vector2.right * MoveSpeed * Time.deltaTime);
                rotationY = 0;
                break;

            case MovementType.Left:
                transform.Translate(Vector2.right * MoveSpeed * Time.deltaTime);
                rotationY = 180;
                break;

            case MovementType.Jump:
                Jump();
                break;

            default:
                Debug.Log("not a movement type");
                break;

        }

        Rotate();
    }

    // return 1 if gravity is normal (or null) or -1 if inverted (To infinity, and beyond!)
    public int GravityCheck()
    {
        if (this.rigidbody2D.gravityScale >= 0) { return 1; }
        else { return -1; }
    }


    public void GravityInvert()
    {
        this.rigidbody2D.gravityScale *= -1;
        Rotate();
    }

    private void Jump()
    {
        if (!isGrounded)
        {
            return;
        }

        this.rigidbody2D.velocity = new Vector2(0, GravityCheck() * jumpSpeed);
        isGrounded = false;
            
    }

    void FixedUpdate()
    {
        isGrounded = (this.rigidbody2D.velocity.y <= 0.75 && this.rigidbody2D.velocity.y >= -0.75 );
    }

    private void InvertAxeY()
    {

        if (rotationY == 0) { rotationY = 180; }
        else if (rotationY == 180) { rotationY = 0; }
    }

    // rotate based on direction and gravity
    private void Rotate()
    {
        rotationX = (GravityCheck() > 0 ? 0 : 180);
        transform.eulerAngles = new Vector2(rotationX, rotationY);
    }
}
