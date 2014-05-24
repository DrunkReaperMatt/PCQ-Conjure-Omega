using UnityEngine;
using System.Collections;

public class MinionCol : MonoBehaviour {

	GameObject[] minions;
	public bool spawn;

	// Use this for initialization
	void Start () {
		minions = GameObject.FindGameObjectsWithTag("minion");
		spawn = false;
		Debug.Log(minions.Length);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		minions = GameObject.FindGameObjectsWithTag("minion");
	}

	public bool IsSpawning(){
		return spawn;
	}

	public bool IsClear(){
		return (minions.Length == 0) ? true : false;
	}
}
