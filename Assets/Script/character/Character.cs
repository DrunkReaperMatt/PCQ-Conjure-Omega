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
        Run,
        Jump,
        Crouch,
        Death,
        Spawn
    }

    public int debugView_CharacterState { get { return (int)State; } }
    public CharacterType characterType;
    public float spawnTime = 3;
    private CharacterState state;

    public AudioSource audioJump;
    public AudioSource audioLanding;
    public AudioSource audioDiePick;

    private Movement movement;
    private Rigidbody2D rigidBody;

    private WayPoint lastWayPoint;
    private float timer = 0;

    void Start()
    {
        movement = GetComponent<Movement>();
        rigidBody = GetComponent<Rigidbody2D>();
        
        //State = CharacterState.Spawn;
    }
    
    void Update()
    {
        if (State == CharacterState.Death || State == CharacterState.Spawn) return; //

        if (movement.IsGrounded)
        {
            float velocityX = rigidBody.velocity.x;
            if(velocityX > 0.05)
            {
                if(movement.IsRunning) { State = CharacterState.Run; }
                else { State = CharacterState.Walk; }
            }
            else
            {
                State = CharacterState.Idle;
            }
        }
        else
        {
            float velocityY = rigidBody.velocity.y;
            
            if(Math.Abs(velocityY) > 0.05)
            {
                State = CharacterState.Jump;
            }
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

    public void Run()
    {

    }

    public void InAir()
    {

    }

    public void Crouch()
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
