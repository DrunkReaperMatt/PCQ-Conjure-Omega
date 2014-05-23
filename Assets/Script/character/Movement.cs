using UnityEngine;
using System.Collections;
using System;

public enum MovementType
{
    Up,
    Down,
    Right,
    Left,
	AttackRapide,
	AttackForte,
	ActivateRage
}

public class Movement : MonoBehaviour {
    
    public float walkSpeed;

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

            //does nothing for now, some contextual actions can be implemented
            case MovementType.Up:
                transform.Translate( Vector3.up * MoveSpeed * Time.deltaTime);				
                break;

            //does nothing for now, some contextual actions can be implemented
            case MovementType.Down:
                transform.Translate(-1 * Vector3.up * MoveSpeed *   Time.deltaTime);
                break;

            case MovementType.Right:
                transform.Translate(Vector3.right * 2 * MoveSpeed * Time.deltaTime);
                rotationY = 0;
                break;

            case MovementType.Left:
                transform.Translate( Vector3.right * 2 * MoveSpeed * Time.deltaTime);
                rotationY = 180;
                break;

			case MovementType.AttackRapide:
				Debug.Log("coup1");
				break;

			case MovementType.AttackForte:
				Debug.Log("coup2");
				break;

			case MovementType.ActivateRage:
				Debug.Log("rage activé");
				break;


            default:
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


  

    

    void FixedUpdate()
    {

    }

    protected void InvertAxeY()
    {

        if (rotationY == 0) { rotationY = 180; }
        else if (rotationY == 180) { rotationY = 0; }
    }

    // rotate based on direction and gravity
	protected void Rotate()
    {
        rotationX = (GravityCheck() > 0 ? 0 : 180);
        transform.eulerAngles = new Vector2(rotationX, rotationY);
    }
}
