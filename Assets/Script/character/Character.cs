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


	public AudioClip attackSound;
	public AudioClip bleedingSound;
	public AudioClip hittingSound;
	public AudioClip dyingSound;
	public AudioClip rageActivationSound;


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
                if(state != CharacterState.Death)
                {
                    state = value;
                    UpdateCharacter();
                }
                else 
                {
                    if (value == CharacterState.Spawn) state = CharacterState.Spawn;
                }
                
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
        
        StartCoroutine("ActionAttack");
    
    }

    public void AttackStrong()
    {
        
        StartCoroutine("ActionAttackStrong");
    }

    public void IsHit()
    {
        anim.Play("Hit");
		AudioSource.PlayClipAtPoint (bleedingSound, transform.position);
        StartCoroutine("ActionIsHit");
    }

    public void Die()
    {
		AudioSource.PlayClipAtPoint (dyingSound, transform.position);
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
			anim.Play("Weak");
			AudioSource.PlayClipAtPoint (attackSound, transform.position);
            float timer = 0f;
            bool attacked = false;

			canAttack = false;
			canMove = false;

            while (timer < ANIM_ATTACK)
            {
				timer += Time.deltaTime;
                if (timer > 0.1f && !attacked)
                {
                    DealDamage(2.2f, damageAttack);
                    attacked = true;
                }
                yield return new WaitForEndOfFrame();
            }

			canAttack = true;
			canMove = true;
        }

		State = CharacterState.Idle;
    }

    public IEnumerator ActionAttackStrong()
    {
		//AudioSource audioSourceObject;
        if (canAttack)
        {
			anim.Play("Strong");
			//audioSourceObject = new AudioSource();
			AudioSource.PlayClipAtPoint (attackSound, transform.position);

            float timer = 0f;
            bool attacked = false;

			canAttack = false;
			canMove = false;

            while (timer < ANIM_STRONG)
            {
                timer += Time.deltaTime;
                if (timer > 0.4f && !attacked) {
                    DealDamage(2.8f, damageAttackStrong);
                    attacked = true;
                }
                yield return new WaitForEndOfFrame();
            }
			//GameObject.Destroy(audioSourceObject);
			canAttack = true;
			canMove = true;
            
        }
		State = CharacterState.Idle;
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

            
        }
		State = CharacterState.Idle;
    }

    public void DealDamage(float range, int damage )
    {
        
        Collider2D[] hitColliders = Physics2D.OverlapAreaAll(
                new Vector2(transform.position.x, transform.position.y + 1),
                new Vector2(transform.position.x + range, transform.position.y - 1)
        );

        Debug.Log(hitColliders.Length);

        foreach (Collider2D collider in hitColliders)
        {

            if (collider.tag == Tag.minion)
            {
				AudioSource.PlayClipAtPoint (hittingSound, transform.position);

                collider.SendMessage("ApplyDamage", new DamageCounter(gameObject, damage));
            }
        }
    }
}
