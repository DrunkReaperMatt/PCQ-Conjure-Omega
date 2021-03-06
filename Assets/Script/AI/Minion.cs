﻿using UnityEngine;
using System.Collections;


public enum MinionType {

	BaseMinion,
	SuperMinion,
	FinalBoss
}

//States pour les animations

/// spawning :  pour charger les ressources et pré creer les minions avant de les faire apparaitre dans la scene.
/// Idling - ne bouge pas : pret a embarquer dans la scene ou trop de minions proche du joueur. 
/// walking : se dirige vers le joueur
/// retreat : quand mode rage activé et moins de 40% vie ou moins de 10%vie?
/// dead : is in dead state. 

public enum MinionState {
	Spawning,
	Idling,
	Walking,
	Retreating, 
	Dead
}

public enum MinionAnimationState {
	None,
	Idling,
	Walking,
	Attacking,
	GettingHit, 
	Dying
}


[RequireComponent(typeof(VitalStats))]
[RequireComponent(typeof(Animator))]

public class Minion : MonoBehaviour {

    private VitalStats vitals;
    private Animator anim;

	public AudioClip DyingSound;

	public bool spawning;

    /*
	public int startingHealth = 100; // maxHealth
	public int startingArmor = 0; //Damage reduction, get higher to add challenge 
	
    */

    public int rotationSpeed = 3;
    public int attackDamage = 10;
    public float movementSpeed = 30;
    public float minAttackDistance = 3.0f;

    public GameObject bloody;

	//private delegate SetDeadState;

	private Movement MinionsMovement;   //memes mouvement que le player (cardinaux), pas de rage.
	private MinionState currentState;  			//movement
	private MinionAnimationState currentAnimationState; // animation
 	
	private const int MIN_HEALTH_TO_RETREAT_UNDER_RAGE_STATE = 35; //percentage
	private const int MIN_HEALTH_TO_RETREAT = 15;

	private const float ANIM_ATTACK_TIME = 2.1f;
	private const float ANIM_IDLE_TIME = 1.3f;



	private Transform playerTargetTransform;
	private Transform currTransform; //local copy for better performance than looking up every frame
	private Rigidbody2D currRigidBody; //local copy for better performance than looking up every frame

	void Awake(){
		currTransform = this.transform;
		currRigidBody = this.rigidbody2D;

	}

	// Use this for initialization
	void Start () {
		currentState = MinionState.Spawning;
		currentAnimationState = MinionAnimationState.Idling;

        vitals = GetComponent<VitalStats>();
		anim = GetComponent<Animator>();

		//optenir la référence vers l'objet player > Mauvaise idée ...
		playerTargetTransform = GameObject.FindWithTag ("Player").transform;

		spawning = false;

	}
	
	// Update is called once per frame
	/*void Update () {


 
	}*/		

	void FixedUpdate(){
		MoveTowardPlayer();
		if (CanAttack()){
			BeginAttackingAnimation();

		}
		else{
			BeginIdlingAnimation();
		}
	}
		                                        
    /*
	public int GetCurrentHealth() {
		return currentHealth;
	}
    */
	private void MoveTowardPlayer(){
		//rotate toward player
		//currTransform.rotation = Quaternion.Slerp(currTransform.rotation, Quaternion.LookRotation(playerTargetTransform.position - currTransform.position), rotationSpeed * Time.deltaTime 


        if (playerTargetTransform != null && currentState != MinionState.Dead)
        {
            //dont rotate clockwise/anticw
            currTransform.rotation = new Quaternion(0, 0, 0, 0);

            //move toward player
            Vector3 direction = new Vector3(Mathf.Round(currTransform.position.x) > Mathf.Round(playerTargetTransform.position.x) ? -1 : 1,
                                              Mathf.Round(currTransform.position.y) > Mathf.Round(playerTargetTransform.position.y) ? -1 : 1,
                                              0);

            ///jiterry
            ///currTransform.position += direction * movementSpeed * Time.deltaTime;

            this.rigidbody2D.velocity = direction * movementSpeed * Time.deltaTime;
        }
        else
        {
            this.rigidbody2D.velocity = new Vector2(0f,0f);
        }
	}

	public void ApplyDamage(DamageCounter dc ) {
        
        if ( currentState != MinionState.Dead ) {
 			vitals.ReceiveDamage(dc.Damage);
			
			if (!vitals.HasHealt())
            {
				StartCoroutine("BeginDyingAnimation");
                currentState = MinionState.Dead;
			}
			else if (shouldRetreat())
            {
				SetRetreatingingState();
			}
		}

	}

    // Deprecated
	public bool IsDead(){
		return vitals.HasHealt();
	}

	private void SetRetreatingingState(){
		currentState = MinionState.Retreating;
	}

	private void SetDyingState(){
		currentAnimationState = MinionAnimationState.Dying;
	}
	private void SetDeadState() {
		currentState = MinionState.Dead;
	}

	public bool shouldRetreat() {
		bool bshouldRetreat = false;
		if ( (vitals.Vitality / vitals.vitalityMax) * 100  < MIN_HEALTH_TO_RETREAT){	
			bshouldRetreat = true;
		}
		//if ((GetCurrentHeat() / MaxHealth) * 100 < MIN_HEALTH_TO_RETREAT_UNDER_RAGE_STATE && PlayerInRageState()){	
		//	bRetreat = true;
		//}

		return bshouldRetreat;
	}

	//Move up = simulation profondeur Z


	// peut attacker si assez proche. (beginAttack())
	// peut pas attacker frame suivi si déjà en animation attaque.
	public bool CanAttack(){

        if (currentState == MinionState.Dead) return false;

		if (this.currentAnimationState == MinionAnimationState.Attacking) {
			return false;
		}
		
		if (  GetDistanceFromPlayer() > minAttackDistance ) {
			return false;
		}

		return true;
	}

	//// ANIMATIONS 
	/// public ou private? 
 
	#region Walking

	public void BeginWalkingAnimation(  ){

		currentAnimationState = MinionAnimationState.Walking;
		StartCoroutine (EndWalkingAnimation());
	}


	public  IEnumerator EndWalkingAnimation( ){
		yield return new WaitForSeconds (ANIM_IDLE_TIME);
		currentAnimationState = MinionAnimationState.None;
	}

	#endregion

	#region Idling
	public void BeginIdlingAnimation( ){
			// anim 


		if (this.tag == Tag.minion) 
		{
			anim.Play("Idle");
		}
/*		if (this.tag == "boss") 
		{
			anim.Play("Eye_Idle");
		}

*/
		if (currentAnimationState == MinionAnimationState.None) {
					
			currentAnimationState = MinionAnimationState.Idling;
			StartCoroutine (EndIdlingAnimation());

		}

	}
	public  IEnumerator EndIdlingAnimation( ){
		yield return new WaitForSeconds (ANIM_IDLE_TIME);
		currentAnimationState = MinionAnimationState.None;
	}

	#endregion
	
	#region Idling
	public void BeginAttackingAnimation( ){
		// anim 
		Debug.Log ("CAN ATTACK!");



		if (this.tag == Tag.minion) 
		{
			anim.Play("Attack");
		}
		/*if (this.tag == "boss") 
		{
			anim.Play("Eye_Attack");
		}
		 */
		if (currentAnimationState == MinionAnimationState.None) {
				currentAnimationState = MinionAnimationState.Attacking;
				StartCoroutine (EndAttackingAnimation ());
		}

}
	public  IEnumerator EndAttackingAnimation( ){
		yield return new WaitForSeconds (ANIM_ATTACK_TIME);
		currentAnimationState = MinionAnimationState.None;
	

		// if Attack collided (player didnt dodge)
				
		GameObject player = GameObject.FindWithTag ("Player");

		player.SendMessage("ApplyDamage", new DamageCounter(null, attackDamage));	
		 


			Debug.Log ("Attack completed! ");
		}

	#endregion
	
	#region Attacking

	public void BeginGettngHitAnimation( ){
		// anim 
		
	 
	}
	#endregion

	#region Dying
 
	private IEnumerator BeginDyingAnimation(){

        Debug.Log("dead");
        anim.Play(null);
        renderer.enabled = false;

        GameObject george = (GameObject)GameObject.Instantiate(bloody,transform.position,transform.rotation);

		AudioSource.PlayClipAtPoint (DyingSound, transform.position);

        yield return new WaitForSeconds(2.5f);

        GameObject.Destroy(george);
        GameObject.Destroy(gameObject);

		// anim 
		//SetDyingState();
		 
	}

	#endregion
	/// POLISH   -- flashy body, before removing from scene.
	public void BeginDecayingBodyAnimation( ){
		// anim 
	}



	public  float GetDistanceFromPlayer(){
		return Vector3.Distance (playerTargetTransform.position, this.currTransform.position);
	}


}
