using UnityEngine;
using System.Collections;
using System;

public enum CharacterType
{
    Blot,
    Blob
}

public class Character : MonoBehaviour
{
    public enum CharacterState
    {
        Idle,
        Walk,
        Death,
        Spawn
    }

    //public float spawnTime = 3;
    private CharacterState state;


    public AudioSource audioLanding;
    public AudioSource audioDiePick;

    private Movement movement;
    private Rigidbody2D rigidBody;


    //private WayPoint lastWayPoint;
    private float timer = 0;

    void Start()
    {
        movement = GetComponent<Movement>();
        rigidBody = GetComponent<Rigidbody2D>();
        
        //State = CharacterState.Spawn;
    }
    
    void Update()
    {
        //if (State == CharacterState.Death || State == CharacterState.Spawn) return; //

		       
	    float velocityX = rigidBody.velocity.x;
			float velocityY = rigidBody.velocity.y;
	    if ((velocityX > 0.05) || (velocityY > 0.05))
	    {
	       State = CharacterState.Walk;
	    }
	    else
	    {
	        State = CharacterState.Idle;
	    }
     
    }
    
    public CharacterState State
    {
        get { return state; }
        set { 
            if (value != this.state)
            {
                state = value;
                UpdateAnimation(this.state);
            } 
        }
    }

    private void UpdateAnimation(CharacterState stateUpdate)
    {

    }

    public void Idle()
    {

    }

    public void Walk()
    {
	

    }


    public void Death()
    {
        if (timer != 0)
        {
            if (timer == Time.time)
            {
                State = CharacterState.Spawn;
                timer = 0;
            }
        }
        else
        {
            timer = Time.time;
        }
        
    }

    public void Spawn()
    {

    }
    /*
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.GetComponent<WayPoint>() != null)
        {
            lastWayPoint = other.transform.GetComponent<WayPoint>();
        }
    }
    */
    public void OnBecameInvisible()
    {
        enabled = false;
    }
}
