using UnityEngine;
using System.Collections;
using System;

public class TestHealtBar : MonoBehaviour {

	private float longeurMax = 0;

	//public Character player;

	public float scaleY;
	public float scalex;

	private float positionX;
	private float positionY;

	// Use this for initialization
	void Start () {

		positionX = 0.2f;
		positionY = 0.9f;


		transform.localPosition = new Vector3(positionX, positionY, 0);


		//transform.localScale = new Vector3 ( longeurMax, 0, 0);
		scaleY = 0;

	}
	
	// Update is called once per frame
	void Update () {
	
		//scalex = ((player.healt / player.HEALT_MAX) - 1);


		transform.localScale = new Vector3 (scalex, scaleY, 0);



		/*if il perd de la vie {
			longeur -= 0.1;
			transform.localScale = new Vector3 ( longeur, 2, 1);
		}

		if il reprend de la vie{
			longeur += 2;
			transform.localScale = new Vector3 ( longeur, 2, 1);*/
	}
}
