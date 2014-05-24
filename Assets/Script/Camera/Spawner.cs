using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
	public bool spawning;


	// Use this for initialization
	void Start () {
		spawning = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.tag == "Player")
		{

			
		}
	}
}
