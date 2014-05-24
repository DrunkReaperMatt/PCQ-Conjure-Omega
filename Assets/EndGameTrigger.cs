using UnityEngine;
using System.Collections;

public class EndGameTrigger : MonoBehaviour {


	void OnTriggerEnter2D(Collider2D col) {
		if (col.tag == Tag.player) {
			Application.LoadLevel ("EndGameCredits");
		}
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
