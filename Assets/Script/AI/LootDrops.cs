using UnityEngine;
using System.Collections;

public enum DropType{
	noDrop,
	smallHealthDrop,
	bigHealthDrop
}

public class LootDrops : MonoBehaviour {

	//private const RND_NO_DROP = 0;		//50%
	private const int RND_SMALL_DROP = 50;	//35%
	private const int RND_BIG_DROP = 85; 	//15%


	//simple loot table
	public static DropType GetRandomDrop(){
		int randomChance = Random.Range(0,100);
	    DropType randomDrop = DropType.noDrop;

		if (randomChance >= RND_BIG_DROP ) {

			randomDrop = DropType.bigHealthDrop;
		}
		else if (randomChance >= RND_SMALL_DROP )  
		{
			randomDrop = DropType.smallHealthDrop;
		}
		//else   //RND_NO_DROP
		 
		return randomDrop;
	}


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
