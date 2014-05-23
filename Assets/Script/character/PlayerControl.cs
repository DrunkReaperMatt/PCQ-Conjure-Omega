using UnityEngine;
using System.Collections;

using System;

public class PlayerControl : MonoBehaviour {

    public bool useGamePad = false;

    public int gamePadNumber = 1;

    // Basic controls
    public KeyCode keyUp;
    public KeyCode keyDown;
    public KeyCode keyRight;
    public KeyCode keyLeft;


    // GamePad Controls
    public KeyCode keyMove;

    // Actions

    private Movement movement;
    private Character character;

    void Start () {
        movement = GetComponent<Movement>();
        //character = GetComponent<Character>();

        if (useGamePad)
        {
            if (gamePadNumber < 1 || gamePadNumber > 4) gamePadNumber = 1;

            //keyUp = keyDown = keyRight = keyLeft = 0;
            

        }

    }
    
    // Update is called once per frame
	void Update () {
        Movement();
	}

    void Movement()
    {
        if (useGamePad)
        {
            float x = Input.GetAxis("Horizontal");
            float y = Input.GetAxis("Vertical");

			Boolean attackRapide = Input.GetButton("Fire1");
			Boolean attackForte = Input.GetButton("Fire2");
			Boolean activateRage = Input.GetButton("Fire3");


            if (x < 0.2 && x > -0.2) x = 0;
            if (y < 0.2 && y > -0.2) y = 0;
            
			if (x > 0) { movement.Move(MovementType.Right); }
			if (x < 0) { movement.Move(MovementType.Left); }
            if (y < 0) { movement.Move(MovementType.Down); }
            if (y > 0) { movement.Move(MovementType.Up); }
			if (attackRapide == true) {movement.Move(MovementType.AttackRapide);}
			if (attackForte == true) {movement.Move(MovementType.AttackForte);}
			if (activateRage == true) {movement.Move(MovementType.ActivateRage);}
        }
        else
        {

			if (Input.GetKey(keyUp)) { movement.Move(MovementType.Up); }
            if (Input.GetKey(keyDown)) { movement.Move(MovementType.Down); }
            if (Input.GetKey(keyRight)) { movement.Move(MovementType.Right); }
            if (Input.GetKey(keyLeft)) { movement.Move(MovementType.Left); }
        }

        // Actions
           
        // Special Actions
        
    }

}
