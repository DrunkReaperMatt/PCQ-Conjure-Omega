﻿using UnityEngine;
using System.Collections;



/// <summary>
/// spawn waves of minion, 
/// </summary>
public class GameController : MonoBehaviour {

	public GameObject minionPrefab;
	public Vector2 defaultSpawnPosition;  // defaut y range middel of simulated 2d floor;
	public float minYSpawnPistionMinion, maxYSpawnPistionMinion;
	public int minionSpawnCount;
	public int minionMaxCount;


	public float minionSpawnWait; /// min time before next minion spawn in current wave. (spawns are also triggered)
	public float startWait;
	public float waveWait; /// min time before next spawn wave. (spawns are also triggered)


	// Use this for initialization
	void Start () {
		StartCoroutine (SpawnWaves ());
	}
	
	// Update is called once per frame
	void Update () {
	
	}




	IEnumerator SpawnWaves ()
	{
		GameObject[] minions;
		int minionsToSpawn;
		yield return new WaitForSeconds (startWait);
		while (true)
		{
			minionsToSpawn = minionSpawnCount; //
			minions = GameObject.FindGameObjectsWithTag("minion");
			if (minions!= null)
			{
				if (minionMaxCount - minions.Length < minionSpawnCount){
					minionsToSpawn = minionMaxCount - minions.Length;
				} 

			}


			for (int i = 0; i < minionsToSpawn; i++)
			{
				Vector2 spawnPosition = new Vector2 (defaultSpawnPosition.x, Random.Range (minYSpawnPistionMinion, maxYSpawnPistionMinion));
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (minionPrefab, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (minionSpawnWait);
			}
			yield return new WaitForSeconds (waveWait);
		}
	}

}