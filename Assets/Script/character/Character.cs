using UnityEngine;
using System.Collections;
using System;

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

    private CharacterState state;

    private Movement movement;
    private VitalStats vitals;
    private Animator anim;

    private int hashMeState = Animator.StringToHash("MeAnimation");

    private bool canAttack;
    private bool canMove;
    private bool canBeHit;

    #region ANIMATION/ACTION TIME

    private const float ANIM_ISHIT = 0.855f;
    private const float ANIM_ATTACK = 0.625f;
    private const float ANIM_STRONG = 1.667f;

    #endregion

    #region ATTACK DAMAGE

    public int damageAttack = 20;
    public int damageAttackStrong = 50;

    #endregion

    void Start()
    {
        Debug.Log("Started");

        state = CharacterState.Spawn;
        canAttack = false;
        canMove = false;

        //movement = GetComponent<Movement>();
        vitals = GetComponent<VitalStats>();
        anim = GetComponent<Animator>();

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
        anim.SetInteger(hashMeState, 0);
    }

    public void Walk()
    {
        anim.SetInteger(hashMeState, 1);
    }

    public void AttackFast()
    {
        anim.SetInteger(hashMeState, 2);
    }

    public void AttackStrong()
    {
        anim.SetInteger(hashMeState, 3);
    }

    public void IsHit()
    {
        anim.SetInteger(hashMeState, 4);
    }

    public void Death()
    {
        canAttack = false;
        canMove = false;
        canBeHit = false;

        anim.enabled = false;
        //animation.Play("Death");
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
        //animation.Play("Spawn");

        canAttack = false;
        canMove = false;
        canBeHit = false;

        anim.enabled = false;

        state = CharacterState.Idle;
    }

    public void ReceivingDamage(GameObject dealer, int damage)
    {
        vitals.ReceiveDamage(damage);
        Debug.Log("Received : " + damage + " <> Remaining : " + vitals.Vitality);
        stillHasHealt();
    }

    public void stillHasHealt()
    {
        if (!vitals.HasHealt())
        {
            state = CharacterState.Death;
        }
    }

    private IEnumerator ActionAttack()
    {
        if (canAttack)
        {
            float timer = 0f;

            canAttack = canMove = false;

            while (timer < ANIM_ATTACK)
            {
                timer += Time.deltaTime;
                if (timer == 0.5f) { /*DealDamage(,);*/ };
                yield return new WaitForEndOfFrame();
            }

            canAttack = canMove = true;
        }
    }

    public IEnumerator ActionAttackStrong()
    {
        if (canAttack)
        {
            float timer = 0f;

            canAttack = canMove = false;

            while (timer < ANIM_ATTACK)
            {
                timer += Time.deltaTime;
                //if (timer == 0.5f) { /*DealDamage(1,1);*/ }
                yield return new WaitForEndOfFrame();
            }

            canAttack = canMove = true;
        }
    }

    public IEnumerator ActionIsHit()
    {
        if (canAttack)
        {
            float timer = 0f;

            canAttack = canMove = false;

            while (timer < ANIM_ATTACK)
            {
                timer += Time.deltaTime;
                yield return new WaitForEndOfFrame();
            }

            canAttack = canMove = true;
        }
    }

    public void DealDamage(float range, int damage )
    {
        Collider[] hitColliders = Physics.OverlapSphere(new Vector2(transform.position.x + range, transform.position.y), 1.5f);
        int i = 0;
        while (i < hitColliders.Length)
        {
            hitColliders[i].SendMessage("ReceiveDamage", new DamageCounter(transform.root.gameObject,damage));
            i++;
        }
    }
}
