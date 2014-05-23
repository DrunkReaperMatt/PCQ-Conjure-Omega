using UnityEngine;
using System.Collections;
using System;

public enum MovementType
{
    Up,
    Down,
    Right,
    Left
}

public class Movement : MonoBehaviour {
    
    public float walkSpeed = 5f;

    private int rotationX = 0;
    private int rotationY = 0;

    private bool lookRight;

    void Start()
    {
        LookRight = true;
    }

    public float MoveSpeed
    {
        get { return (walkSpeed); }
    }
	
    public void Move(MovementType type)
    {
        
        switch (type)
        {

            case MovementType.Up:
                transform.Translate( Vector3.up * MoveSpeed * Time.deltaTime);				
                break;

            case MovementType.Down:
                transform.Translate(-1 * Vector3.up * MoveSpeed * Time.deltaTime);
                break;

            case MovementType.Right:
                transform.Translate(Vector3.right * 2 * MoveSpeed * Time.deltaTime);
                LookRight = true;
                break;

            case MovementType.Left:
                transform.Translate(-1 * Vector3.right * 2 * MoveSpeed * Time.deltaTime);
                LookRight = false;
                break;

            default:
                break;

        }

        //Rotate();
    }

    public bool LookRight
    {
        get { return lookRight; }
        set
        {
            if (lookRight != value)
            {
                lookRight = !lookRight;
                SetLookDirection();
            }
        }
    }

    public void SetLookDirection()
    {
        transform.localScale = new Vector2((lookRight ? -1 : 1), 1);
    }

    
}
