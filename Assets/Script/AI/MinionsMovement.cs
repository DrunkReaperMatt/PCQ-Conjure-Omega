using UnityEngine;
using System.Collections;

/// GROUP movement AI.
/// 
/// Éviter de trop swarmer le player si trop de mob dans un meme coin.  Faut pas qu'il se sente one shot killer sinon rage quit!:P
/// 
/// SINGLETON.    Billboard pattern.  
/// 				Mouvement en squad (max de 4)
/// 				Avoir la liste des minions vivant; squad le plus proche attaque, les autres se rapproche jusqu'a distance critique
/// 				Collision. Ne pas empiler les minions un sur l'autre. (position x et y). Doit simuler profondeur
/// 
/// 
/// 
public class MinionsMovement : MonoBehaviour {

	public int MAX_ATTACKING_MINIONS = 4;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	Minion[] GetClosestMinions()
	{
		Minion[] squad = new Minion[MAX_ATTACKING_MINIONS];
		
		Minion[] remainingActiveMinions;


		
		//GetPlayerPos;

		// GameObject.FindAll ( tag minion ou type)
			// for each minion
				//add to remainingActiveMinions
				
			
			// sort by distance
			
			// prendre ceux déja en attacking state. (rien faire, on déja attacké au frame précédent
				//minion.getCurrentAnimationState

			// si  nb attacking < MAX NB AT			

			// up to first MAX_ATTACKING_MINIONS : remove and att ot attacking minions. 

			// si distance assez proche, beginAttackAnimation()

		return squad;
	}

	//for managing squads, need to know each's position.
	//	Vector2 GetPosition(){
	//		return  GameObject position 
	//	}
}
