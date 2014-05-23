using UnityEngine;
using System.Collections;



/// <summary>
/// spawn waves of minion, 
/// </summary>
public class GameController : MonoBehaviour {

	public GameObject minionPrefab;
	public Vector2 defaultSpawnPosition;  // defaut y range middel of simulated 2d floor;
	public float minYSpawnPistionMinion, maxYSpawnPistionMinion;
	public int minionSpawnCount;

	public float spawnWait; /// min time before next spawn wave. (spawns are also triggered)
	public float startWait;
	public float waveWait;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}




	IEnumerator SpawnWaves ()
	{
		yield return new WaitForSeconds (startWait);
		while (true)
		{
			for (int i = 0; i < minionSpawnCount; i++)
			{
				Vector2 spawnPosition = new Vector2 (defaultSpawnPosition.x, Random.Range (minYSpawnPistionMinion, maxYSpawnPistionMinion));
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (minionPrefab, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (waveWait);
		}
	}

}
