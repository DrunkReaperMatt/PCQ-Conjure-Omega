﻿using UnityEngine;
using System.Collections;

public class EndGameCredits : MonoBehaviour {

	public int delaiEntreEcrans = 3;

	private GameObject gc0;
	private GameObject gc1;  
	private GameObject gc2; 
	private GameObject gc3; 

	// Use this for initialization
	void Start () {
		Debug.Log ("Credits Start()");
		gc0 = GameObject.Find ("EndGame");
		gc1 = GameObject.Find ("Credit1");
		gc2 = GameObject.Find ("Credit2");
		gc3 = GameObject.Find ("Credit3");

		StartCoroutine ( ShowCredits () );
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)   ) {
			Application.LoadLevel ("menu_principal");
		}
	}

	IEnumerator ShowCredits(){
		Debug.Log ("ShowCredits()");
		int i = 0;

		gc0.renderer.enabled = true;
		yield return new WaitForSeconds (delaiEntreEcrans);

		while (true) {

				gc0.renderer.enabled = false;
				gc1.renderer.enabled = (i % 3 == 0);
				gc2.renderer.enabled = (i % 3 == 1);
				gc3.renderer.enabled = (i % 3 == 2);
				i += 1;
				yield return new WaitForSeconds (delaiEntreEcrans);

		}

	}
}