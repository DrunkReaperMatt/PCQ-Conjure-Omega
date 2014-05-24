using UnityEngine;
using System.Collections;
using System;

public class HealtBarEnemy : MonoBehaviour {
	
	
	public Minion player;
	public GameObject go;
	
	private float scaleY;
	private float scaleX;
	
	private float positionX;
	private float positionY;
	
	// Use this for initialization
	void Start () {
		
		go = GameObject.FindGameObjectWithTag ("Player");
		player = go.GetComponent<Minion> ();
		
		
		positionX = -1f;
		positionY = 1.75f;
		
		
		transform.localPosition = new Vector3(positionX, positionY, 0);
		
		
		scaleX = 0.01f;
		scaleY = 0.01f;
		transform.localScale = new Vector3 (scaleX, scaleY, 0);
		
	}
	
	// Update is called once per frame
	void Update () {
		
		
		//ajuste la longeur de la bar selon la quantité de vie qu'il reste
		scaleX = ((float)player.GetCurrentHealth() / (float)player.startingHealth);
		
		transform.localScale = new Vector3 (scaleX, scaleY, 0);

		Debug.Log(scaleX);

		if (Input.GetKey("l") && player.GetCurrentHealth()>0) { 
			player.ReceiveDamage(1);

		}
				
	}
}
