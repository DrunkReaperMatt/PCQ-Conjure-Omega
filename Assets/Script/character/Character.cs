using UnityEngine;
using System.Collections;
using System;


[RequireComponent(typeof(Movement))]
[RequireComponent(typeof(VitalStats))]
[RequireComponent(typeof(Animator))]

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

    //private Movement movement;
    private VitalStats vitals;
    private Animator anim;

    private int hashMeState = Animator.StringToHash("MeAnimation");

    private bool canAttack;
    private bool canMove;
    private bool canBeHit;

    #region ANIMATION/ACTION TIME

    private const float ANIM_ISHIT = 0.820f;//0.855f;
    private const float ANIM_ATTACK = 0.600f;//0.625f;
    private const float ANIM_STRONG = 1.620f;//1.667f;

    #endregion

    #region ATTACK DAMAGE

    public int damageAttack = 20;
    public int damageAttackStrong = 50;
    public float rageMultiplier = 1.50f;
    #endregion

    void Start()
    {

        canAttack = false;
        canMove = false;

        //movement = GetComponent<Movement>();
        vitals = GetComponent<VitalStats>();
        anim = GetComponent<Animator>();

        State = CharacterState.Spawn;

    }

    #region ACCESSOR/MUTATOR

    public CharacterState State
    {
        get { return state; }
        set {
            if (value != this.state)
            {
                state = value;
                Debug.Log(state);
                UpdateCharacter();
            } 
        }
    }

    public bool CanMove
    {
        get { return canMove; }
    }

    public bool CanAttack
    {
        get { return canAttack; }
    }

    public bool CanBeHit
    {
        get { return canBeHit; }
    }

    #endregion

    #region STATE ACTIONS

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

            case CharacterState.Spawn:
                Spawn();
                break;

            case CharacterState.Death:
                Die();
                break;

            default:

                break;
        }
    }

    public void Idle()
    {
        anim.Play("Idle");
    }

    public void Walk()
    {
        anim.Play("Walk");
    }

    public void AttackFast()
    {
        anim.Play("Attack");
        StartCoroutine("ActionAttack");
    }

    public void AttackStrong()
    {
        anim.Play("Strong");
        StartCoroutine("ActionAttackStrong");
    }

    public void IsHit()
    {
        anim.Play("Hit");
        StartCoroutine("ActionIsHit");
    }

    public void Die()
    {
        canAttack = false;
        canMove = false;
        canBeHit = false;

        anim.enabled = false;
    }

    public void Spawn()
    {
        canAttack = true;
        canMove = true;
        canBeHit = true; // put god mode here

        //anim.enabled = true;
        
        state = CharacterState.Idle;
    }

    #endregion

    public void ApplyDamage(DamageCounter dc)
    {
        if (canBeHit)
        {
            vitals.ReceiveDamage(dc.Damage);
            stillHasHealt();
        }
        else { Debug.Log("Invulnerable"); }
        
    }

    public void stillHasHealt()
    {
        if (!vitals.HasHealt())
        {
            State = CharacterState.Death;
        }
        else if (state != CharacterState.AttackFast && state != CharacterState.AttackStrong)
        {
            State = CharacterState.IsHit;
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
            State = CharacterState.Idle;
        }
    }

    public IEnumerator ActionAttackStrong()
    {
        if (canAttack)
        {
            float timer = 0f;

            canAttack = canMove = false;

            while (timer < ANIM_STRONG)
            {
                timer += Time.deltaTime;
                //if (timer == 0.5f) { /*DealDamage(1,1);*/ }
                yield return new WaitForEndOfFrame();
            }

            canAttack = canMove = true;
            State = CharacterState.Idle;
        }
    }

    public IEnumerator ActionIsHit()
    {
        if (canBeHit)
        {
            float timer = 0f;

            canAttack = canMove = canBeHit = false;

            while (timer < ANIM_ISHIT)
            {
                timer += Time.deltaTime;
                yield return new WaitForEndOfFrame();
            }

            canAttack = canMove = canBeHit = true;

            State = CharacterState.Idle;
        }
    }

    public void DealDamage(float range, int damage )
    {
        Collider[] hitColliders = Physics.OverlapSphere(new Vector2(transform.position.x + (-transform.localScale.x * range), transform.position.y), 1.5f);
        int i = 0;
        while (i < hitColliders.Length)
        {
            hitColliders[i].SendMessage("ApplyDamage", new DamageCounter(transform.root.gameObject,damage));
            i++;
        }
    }
}
