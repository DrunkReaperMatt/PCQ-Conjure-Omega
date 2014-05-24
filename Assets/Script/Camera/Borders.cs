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

		}

		if(col.gameObject.tag == "minion"){
			Debug.Log("Patate");
			Physics2D.IgnoreLayerCollision(0, 9, true);
		}
	}
}
