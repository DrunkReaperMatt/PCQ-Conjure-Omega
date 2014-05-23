using UnityEngine;
using System.Collections;

public class Borders : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.tag == "Player"){
			Debug.Log("Patate");
		}

		if(col.gameObject.tag == "minion"){
			Physics.IgnoreCollision(col.transform.collider2D, collider2D);
		}
	}
}
