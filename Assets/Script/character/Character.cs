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
        AttackFast,
        AttackStrong,
        IsHit,
        Death,
        Spawn,
        Invulnerable
    }

    //public float spawnTime = 3;
    private CharacterState state;

    private Movement movement;
    private VitalStats vitals;

    private bool canAttack;
    private bool canMove;

    //private WayPoint lastWayPoint;
    private float timer = 0;

    void Start()
    {

        canAttack = false;
        canMove = false;

        movement = GetComponent<Movement>();
        vitals = GetComponent<VitalStats>();
    }
    
    /*
    void Update()
    {
     
    }
    */
   
    public CharacterState State
    {
        get { return state; }
        set { 
            if (value != this.state)
            {
                state = value;
            } 
        }
    }


    public void Idle()
    {
        animation.Play("Idle");
    }

    public void Walk()
    {
        animation.Play("Walk");
    }

    public void AttackFast()
    {
        animation.Play("AttackFast");
    }

    public void AttackStrong()
    {
        animation.Play("AttackStrong");
    }

    public void IsHit()
    {
        animation.Play("IsHit");
    }

    public void Death()
    {
        animation.Play("Death");
        /*
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
        */
    }

    public void Spawn()
    {
        animation.Play("Spawn");
    }

    public void ReceivingDamage(GameObject dealer, int damage)
    {

    }

    public void stillHasHealt()
    {
        if (!vitals.HasHealt())
        {

        }
    }
}
