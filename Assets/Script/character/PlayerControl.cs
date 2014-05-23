using UnityEngine;
using System.Collections;

using System;

[RequireComponent(typeof(Character))]
[RequireComponent(typeof(Movement))]

public class PlayerControl : MonoBehaviour {

    public bool useGamePad = false;

    public int gamePadNumber = 1;

    // Basic controls
    public KeyCode keyUp;
    public KeyCode keyDown;
    public KeyCode keyRight;
    public KeyCode keyLeft;

    public KeyCode keyAttack;
    public KeyCode keyAttackStrong;
    //public KeyCode keyActivateRage;

    // GamePad Controls
    public KeyCode keyMove;

    // Actions

    private Movement movement;
    //private Character character;

    void Start () {

        movement = GetComponent<Movement>();
        character = GetComponent<Character>();

        if (useGamePad)
        {
            if (gamePadNumber < 1 || gamePadNumber > 4) gamePadNumber = 1;
        }

    }
    
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
			//Boolean activateRage = Input.GetButton("Fire3");

            if (x < 0.2 && x > -0.2) x = 0;
            if (y < 0.2 && y > -0.2) y = 0;

            Debug.Log((character.CanMove ? "yo, i can move" : "i am stuck"));

            if(character.CanMove)
            {
			    if (x > 0) { movement.Move(MovementType.Right); }
			    if (x < 0) { movement.Move(MovementType.Left); }
                if (y < 0) { movement.Move(MovementType.Down); }
                if (y > 0) { movement.Move(MovementType.Up); }
            }

            if (character.CanAttack)
            {
                if (attackRapide == true) { character.State = Character.CharacterState.AttackFast; }
                if (attackForte == true) { character.State = Character.CharacterState.AttackStrong; }
                //if (activateRage == true) { character.RageModeActivation; }
            }
        }
        else
        {
            if (character.CanMove)
            {
                if (Input.GetKey(keyUp)) { movement.Move(MovementType.Up); }
                if (Input.GetKey(keyDown)) { movement.Move(MovementType.Down); }
                if (Input.GetKey(keyRight)) { movement.Move(MovementType.Right); }
                if (Input.GetKey(keyLeft)) { movement.Move(MovementType.Left); }
            }
            
            if(character.CanAttack)
            {
                if (Input.GetKey(keyAttack)) { character.State = Character.CharacterState.AttackFast; }
                if (Input.GetKey(keyAttackStrong)) { character.State = Character.CharacterState.AttackFast; }
                //if (Input.GetKey(keyActivateRage)) { character.RageModeActivation; }
            }
        }
        
    }

}
