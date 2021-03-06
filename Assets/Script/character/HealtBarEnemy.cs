﻿using UnityEngine;
using System.Collections;
using System;

public class HealtBarEnemy : MonoBehaviour {
	
	
	public VitalStats player;
	public GameObject go;
	
	private float scaleY;
	private float scaleX;
	
	private float positionX;
	private float positionY;
	
	// Use this for initialization
	void Start () {
		
		go = GameObject.FindGameObjectWithTag ("Player");
		player = go.GetComponent<VitalStats> ();
		
		
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
		scaleX = ((float)player.GetComponent<VitalStats>().Vitality / (float)player.GetComponent<VitalStats>().vitalityMax)/100;
		
		transform.localScale = new Vector3 (scaleX, scaleY, 0);

		Debug.Log(scaleX);

		if (Input.GetKey("l") && player.GetComponent<VitalStats>().Vitality > 0) { 
			player.GetComponent<VitalStats>().ReceiveDamage(1);

		}
				
	}
}
