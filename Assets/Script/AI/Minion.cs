using UnityEngine;
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
	Idling,
	Walking,
	Attacking,
	GettingHit, 
	Dying
}



public class Minion : MonoBehaviour {

	public int startingHealth = 100; // maxHealth
	public int startingArmor = 0; //Damage reduction, get higher to add challenge 

	//private delegate SetDeadState;

	private int currentHealth;
	private Movement movement;   //memes mouvement que le player (cardinaux), pas de rage.
	private MinionState currentState;  			//movement
	private MinionAnimationState currentAnimationState; // animation
 	
	private const int MIN_HEALTH_TO_RETREAT_UNDER_RAGE_STATE = 35; //percentage
	private const int MIN_HEALTH_TO_RETREAT = 15;

	// Use this for initialization
	void Start () {
		currentState = MinionState.Spawning;
		currentAnimationState = MinionAnimationState.Idling;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public int GetCurrentHealth() {
		return currentHealth;
	}


	public void ReceiveDamage(int dmg) {
<<<<<<< HEAD
		if ( currentState != MinionState.Dead ) {
=======
		if (currentState != MinionState.Dead || currentAnimationState != MinionAnimationState.Dying) {
>>>>>>> ee8fe2e859b578b635159a85656b784b271656f9
			currentHealth -= dmg;
			//Killing blow? set dying stage. 
			if (IsDead()){
				SetDyingState();
			}
			else if (shouldRetreat()){
				SetRetreatingingState();
			}
		} 

	}

	public bool IsDead(){
		return GetCurrentHealth() <= 0;
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
<<<<<<< HEAD
		bool bshouldRetreat = false;
		if ( (GetCurrentHealth() / startingHealth) * 100  < MIN_HEALTH_TO_RETREAT){	
			bshouldRetreat = true;
=======
		bool bRetreat = false;
		if ( (GetCurrentHealth() / startingHealth) * 100  < MIN_HEALTH_TO_RETREAT){	
			bRetreat = true;
>>>>>>> ee8fe2e859b578b635159a85656b784b271656f9
		}
		//if ((GetCurrentHeat() / MaxHealth) * 100 < MIN_HEALTH_TO_RETREAT_UNDER_RAGE_STATE && PlayerInRageState()){	
		//	bRetreat = true;
		//}

		return bshouldRetreat;
	}

	//Move up = simulation profondeur Z



	//// ANIMATIONS 
	/// public ou private? 
<<<<<<< HEAD

	public void BeginWalkingAnimation(  ){
		// anim 

	 
=======
	/*
	public void BeginWalkingAnimation( EventDelegate funcWhenDone){
		// anim 

		funcWhenDone();
>>>>>>> ee8fe2e859b578b635159a85656b784b271656f9
	}

	public void BeginIdlingAnimation( ){
		// anim 
		
<<<<<<< HEAD
 
=======
		funcWhenDone();
>>>>>>> ee8fe2e859b578b635159a85656b784b271656f9
	}

	public void BeginAttackingAnimation( ){
		// anim 
		
<<<<<<< HEAD
	 
=======
		funcWhenDone();
>>>>>>> ee8fe2e859b578b635159a85656b784b271656f9
	}

	public void BeginGettngHitAnimation( ){
		// anim 
		
	 
	}


	//funcWhenDone - BeginDecayingBodyAnimation
	public void BeginDyingAnimation( ){
		// anim 
		
		 
	}

	/// POLISH   -- flashy body, before removing from scene.
	public void BeginDecayingBodyAnimation( ){
		// anim 
		
<<<<<<< HEAD
		 
=======
		funcWhenDone();
>>>>>>> ee8fe2e859b578b635159a85656b784b271656f9
	}

*/
}
