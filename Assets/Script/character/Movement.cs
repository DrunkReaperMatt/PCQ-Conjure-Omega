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

    void Start()
    {
        Rotate();
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
                gameObject.transform.Translate( Vector3.up * MoveSpeed * Time.deltaTime);				
                break;

            case MovementType.Down:
                gameObject.transform.Translate(-1 * Vector3.up * MoveSpeed * Time.deltaTime);
                break;

            case MovementType.Right:
                gameObject.transform.Translate(Vector3.right * 2 * MoveSpeed * Time.deltaTime);
                //rotationY = 0;
                break;

            case MovementType.Left:
                gameObject.transform.Translate(Vector3.right * 2 * MoveSpeed * Time.deltaTime);
                //rotationY = 180;
                break;

            default:
                break;

        }

        Rotate();
    }

    // return 1 if gravity is normal (or null) or -1 if inverted (To infinity, and beyond!)
  
    protected void InvertAxeY()
    {

        if (rotationY == 0) { rotationY = 180; }
        else if (rotationY == 180) { rotationY = 0; }
    }

    // rotate based on direction and gravity
	protected void Rotate()
    {
        //rotationX = (GravityCheck() > 0 ? 0 : 180);
        transform.eulerAngles = new Vector2(rotationX, rotationY);
    }
}
