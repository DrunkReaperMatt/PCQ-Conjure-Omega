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
    public KeyCode keyJump;

    // Actions
    public KeyCode keyRun;
    public KeyCode keyInvertGravity;
    public KeyCode keySelfDestruct;

    private Movement movement;
    private Character character;

    void Start () {
        movement = GetComponent<Movement>();
        character = GetComponent<Character>();

        if (useGamePad)
        {
            if (gamePadNumber < 1 || gamePadNumber > 4) gamePadNumber = 1;

            //keyUp = keyDown = keyRight = keyLeft = 0;
            
            keyRun = (KeyCode)Enum.Parse(typeof(KeyCode), "Joystick" + gamePadNumber + "Button2");
            keyInvertGravity = (KeyCode)Enum.Parse(typeof(KeyCode), "Joystick" + gamePadNumber + "Button3");
            keySelfDestruct = (KeyCode)Enum.Parse(typeof(KeyCode), "Joystick" + gamePadNumber + "Button6");

            keyJump = (KeyCode)Enum.Parse(typeof(KeyCode), "Joystick" + gamePadNumber + "Button0");

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

            if (x < 0.2 && x > -0.2) x = 0;
            if (y < 0.2 && y > -0.2) y = 0;
            
            if (x != 0) { movement.Move(x); }
            if (y < 0) { movement.Move(MovementType.Down); }
            if (y > 0) { movement.Move(MovementType.Up); }
            
        }
        else
        {

            if (Input.GetKeyDown(keyUp)) { movement.Move(MovementType.Up); }
            if (Input.GetKey(keyDown)) { movement.Move(MovementType.Down); }
            if (Input.GetKey(keyRight)) { movement.Move(MovementType.Right); }
            if (Input.GetKey(keyLeft)) { movement.Move(MovementType.Left); }
        }

        // Actions
        if (Input.GetKeyDown(keyInvertGravity)) { movement.GravityInvert(); }
        if (Input.GetKeyDown(keyRun)) { movement.IsRunning = true; }
        if (Input.GetKeyUp(keyRun)) { movement.IsRunning = false; }
        if (Input.GetKeyDown(keySelfDestruct)) { character.State = Character.CharacterState.Death; }
           
        // Special Actions
        if (Input.GetKeyDown(keyJump)) { movement.Move(MovementType.Jump); }
        //if (Input.GetKeyUp(keyJump)) { movement.Move(Jump()); }
    }

}
