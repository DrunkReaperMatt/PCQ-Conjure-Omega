using UnityEngine;
using System.Collections;
using System;

public class Character : MonoBehaviour
{
    public enum CharacterState
    {
        Idle,
        Walk,
        Death,
        Attack1,
        Attack2,
        Attack3,
        GettingHit,
        Spawn,
        Invulnerable
    }

    //public int debugView_CharacterState { get { return (int)State; } }

    public float spawnTime = 3;
    private CharacterState state;

    private Movement movement;
    private VitalStats vitals;

    private float timer = 0;

    void Start()
    {
        movement = GetComponent<Movement>();
        vitals = GetComponent<VitalStats>();

        state = CharacterState.Spawn;
    }

    void Update()
    {
        if (State == CharacterState.Death || State == CharacterState.Spawn) return; //



    }

    public CharacterState State
    {
        get { return state; }
        set
        {
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

    public void Move()
    {
        animation.Play("Move");
    }
    public void Attack1()
    {
        animation.Play("Attack1");
    }
    public void Attack2()
    {
        animation.Play("Attack2");
    }
    public void Attack3()
    {
        animation.Play("Attack3");
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

    public void ReceiveDamage(GameObject dealer, int damage)
    {

        if (State == CharacterState.Death || State == CharacterState.Spawn)
        {

        }
        else if (state == CharacterState.Invulnerable)
        {

        }
        else
        {
            vitals.ReceiveDamage(damage);

            CheckVitals();
        }
    }

    public void CheckVitals() 
    {
        if (!vitals.HasHealt())
        {

            State = CharacterState.Death;
        }
    }

}
