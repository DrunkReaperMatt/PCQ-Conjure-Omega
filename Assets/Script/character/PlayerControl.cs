using UnityEngine;
using System.Collections;

using System;


[RequireComponent(typeof(Character))]

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
    private Character character;

    void Start () {
        transform.localScale = new Vector2(-1,1);
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

			Boolean attackRapide = Input.GetKey (keyAttack);// Input.GetButton("Fire1");
			Boolean attackForte = Input.GetKey (keyAttackStrong);
			//Boolean activateRage = Input.GetButton("Fire3");

            if (x < 0.2 && x > -0.2) x = 0;
            if (y < 0.2 && y > -0.2) y = 0;

            //Debug.Log((character.CanMove ? "yo, i can move" : "i am stuck"));

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
            bool isWalking = false;

            //Debug.Log((character.CanMove ? "Yup can move" : "Can not !") + " <-> " + character.GetComponent<VitalStats>().Vitality);

            if (character.CanMove)
            {
                if (Input.GetKey(keyUp)) { movement.Move(MovementType.Up); isWalking = true; }
                if (Input.GetKey(keyDown)) { movement.Move(MovementType.Down); isWalking = true; }
                if (Input.GetKey(keyRight)) { movement.Move(MovementType.Right); isWalking = true; }
                if (Input.GetKey(keyLeft)) { movement.Move(MovementType.Left); isWalking = true; }
            }

            if (isWalking) character.State = Character.CharacterState.Walk;
            else if (character.CanMove) character.State = Character.CharacterState.Idle;

            if(character.CanAttack)
            {
                if (Input.GetKey(keyAttack)) { character.State = Character.CharacterState.AttackFast; }
                if (Input.GetKey(keyAttackStrong)) { character.State = Character.CharacterState.AttackStrong; }
                //if (Input.GetKey(keyActivateRage)) { character.RageModeActivation; }
            }
            
        }
        
    }

}
