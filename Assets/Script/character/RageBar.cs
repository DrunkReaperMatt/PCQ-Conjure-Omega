using UnityEngine;
using System.Collections;
using System;

public class RageBar : MonoBehaviour {


	public VitalStats player;

	private float scaleY;
	private float scaleX;

	private float positionX;
	private float positionY;

	// Use this for initialization
	void Start () {


		positionX = -250;
		positionY = 220;


		transform.localPosition = new Vector3(positionX, positionY, 0);


		//transform.localScale = new Vector3 ( longeurMax, 0, 0);

		scaleX = player.Rage / player.rageMax;
		scaleY = 1;
		transform.localScale = new Vector3 (scaleX, scaleY, 0);

	}
	
	// Update is called once per frame
	void Update () {
	
		scaleX = player.Rage / player.rageMax;

		transform.localScale = new Vector3 (scaleX, scaleY, 0);

		if (Input.GetKey("k")) { 
			player.ReceiveDamage(1); 
			Debug.Log(player.Vitality);
		}
		
		if (Input.GetKey("o") && player.Vitality <100) { 
			player.GainHealt(1); 
			Debug.Log(player.Vitality);
		}

	
	}
}
