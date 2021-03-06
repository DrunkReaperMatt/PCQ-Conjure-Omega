﻿using UnityEngine;
using System.Collections;



/// <summary>
/// spawn waves of minion, 
/// </summary>
public class GameController : MonoBehaviour {

	public GameObject minionPrefab;
	private GameObject camera;
	public CameraControls tracking;
	public Vector2 defaultSpawnPosition;  // defaut y range middel of simulated 2d floor;
	public float minYSpawnPistionMinion, maxYSpawnPistionMinion;
	public int minionSpawnCount;
	public int minionMaxCount;


	public float minionSpawnWait; /// min time before next minion spawn in current wave. (spawns are also triggered)
	public float startWait;
	public float waveWait; /// min time before next spawn wave. (spawns are also triggered)

	MinionCol go;
	bool spawning;

	// Use this for initialization
	void Start () {
		//StartCoroutine (SpawnWaves ());
		camera = GameObject.FindGameObjectWithTag("MainCamera");
		tracking = camera.GetComponent<CameraControls>();
		go = GameObject.Find("_Minion Counter").GetComponent<MinionCol>();
		spawning = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (go != null) {				
				go.spawn = spawning;
		}
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.tag == "Player" && !spawning){
			spawning = true;
			StartCoroutine(SpawnWaves());
			tracking.tracking = false;
		}
	}

	public bool IsSpawning(){
		return spawning;
	}

	IEnumerator SpawnWaves ()
	{
		GameObject[] minions;
		int minionsToSpawn;
		spawning = true;
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

			for (int i = 0; i < minionsToSpawn; i++){
				Vector3 spawnPosition = new Vector3 (defaultSpawnPosition.x, Random.Range (minYSpawnPistionMinion, maxYSpawnPistionMinion), -4.1f);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (minionPrefab, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (minionSpawnWait);
			}
			yield return new WaitForSeconds (waveWait);
			spawning = false;
			Destroy(gameObject);
		}
	}

}
