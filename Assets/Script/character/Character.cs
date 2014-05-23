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

    //private Movement movement;
    private VitalStats vitals;
    private Animator animator;

    private bool canAttack;
    private bool canMove;

    //private WayPoint lastWayPoint;
    private float timer = 0;

    void Start()
    {
        state = CharacterState.Spawn;
        canAttack = false;
        canMove = false;

        //movement = GetComponent<Movement>();
        vitals = GetComponent<VitalStats>();

        State = CharacterState.IsHit;
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
                UpdateCharacter();
            } 
        }
    }

    public void UpdateCharacter() 
    {
        switch (state)
        {
            case CharacterState.Idle:
                Idle();
                break;

            case CharacterState.Walk:
                Walk();
                break;

            case CharacterState.AttackFast:
                AttackFast();
                break;

            case CharacterState.AttackStrong:
                AttackStrong();
                break;

            case CharacterState.IsHit:
                IsHit();
                break;

            default:

                break;
        }
    }

    public void Idle()
    {
        animation.CrossFade("Idle");
    }

    public void Walk()
    {
        animation.Play("Walk");
    }

    public void AttackFast()
    {
        animation.Play("Attack");
    }

    public void AttackStrong()
    {
        animation.Play("Strong");
    }

    public void IsHit()
    {
        animation.Play();
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
