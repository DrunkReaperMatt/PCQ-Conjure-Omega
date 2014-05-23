using UnityEngine;
using System.Collections;
using System;

public class Character : MonoBehaviour
{
    public enum CharacterState
    {
        Idle, // 0
        Walk, // 1
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

    private const float ANIM_ISHIT = 0.820f;//0.855f;
    private const float ANIM_ATTACK = 0.600f;//0.625f;
    private const float ANIM_STRONG = 1.620f;//1.667f;

    #endregion

    #region ATTACK DAMAGE

    public int damageAttack = 20;
    public int damageAttackStrong = 50;

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
        anim.SetInteger(hashMeState, (int) CharacterState.Idle);
    }

    public void Walk()
    {
        anim.SetInteger(hashMeState, (int)CharacterState.Walk);
    }

    public void AttackFast()
    {
        anim.SetInteger(hashMeState, (int)CharacterState.AttackFast);
        StartCoroutine("ActionAttack");
    }

    public void AttackStrong()
    {
        anim.SetInteger(hashMeState, (int)CharacterState.AttackStrong);
        StartCoroutine("ActionAttackStrong");
    }

    public void IsHit()
    {
        anim.SetInteger(hashMeState, (int)CharacterState.IsHit);
        StartCoroutine("ActionIsHit");
    }

    public void Die()
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

        canAttack = true;
        canMove = true;
        canBeHit = true; // put god mode here

        anim.enabled = true;
        
        state = CharacterState.Idle;
    }

    public void ApplyDamage(DamageCounter dc)
    {
        if (canBeHit)
        {
            vitals.ReceiveDamage(dc.Damage);
            Debug.Log("Received : " + dc.Damage + " <> Remaining : " + vitals.Vitality);
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
        else
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

            while (timer < ANIM_ATTACK)
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
                Debug.Log("Timer : " + timer + " <> " + ANIM_ISHIT);
                yield return new WaitForEndOfFrame();
            }

            canAttack = canMove = canBeHit = true;

            State = CharacterState.Idle;
        }
    }

    public void DealDamage(float range, int damage )
    {
        Collider[] hitColliders = Physics.OverlapSphere(new Vector2(transform.position.x + range, transform.position.y), 1.5f);
        int i = 0;
        while (i < hitColliders.Length)
        {
            hitColliders[i].SendMessage("ApplyDamage", new DamageCounter(transform.root.gameObject,damage));
            i++;
        }
    }
}
