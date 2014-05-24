using UnityEngine;
using System.Collections;
using System;

public class RageBar2 : MonoBehaviour {
	
	
	public VitalStats player;
	public GameObject go;
	
	private float scaleY;
	private float scaleX;
	
	public float positionX;
	public float positionY;
	
	// Use this for initialization
	void Start () {
		go = GameObject.FindGameObjectWithTag("Player");
		player = go.GetComponent<VitalStats> ();
		
		positionX = transform.position.x;
		positionY = transform.position.y;
		
		
		//transform.localPosition = new Vector3(positionX, positionY, 0);

		scaleX = 0f;

		scaleY = 1;
		transform.localScale = new Vector3 (scaleX, scaleY, 0);
		
	}
	
	// Update is called once per frame
	void Update () {

		//ajuste la longeur de la bar selon la quantité de rage qu'il a d'accumulé
		scaleX = ((float)player.Rage / (float)player.rageMax);
		
		transform.localScale = new Vector3 (scaleX, scaleY, 0);


		if (Input.GetKey("k") && player.Rage > 0) { 
			player.SpendRage(1); 
			Debug.Log(player.Rage);
		}
		
		if (Input.GetKey("o") && player.Rage < player.rageMax) { 
			player.GainRage(1); 
			Debug.Log(player.Rage);
		}
		
		
	}
}
