using UnityEngine;
using System.Collections;
using System;

public class HealthBar2 : MonoBehaviour {


	public VitalStats player;
	public GameObject go;

	private float scaleY;
	private float scaleX;

	public float positionX;
	public float positionY;

	// Use this for initialization
	void Start () {

		go = GameObject.FindGameObjectWithTag ("Player");
		player = go.GetComponent<VitalStats> ();


		positionX = transform.position.x;
		positionY = transform.position.y;


		//transform.localPosition = new Vector3(positionX, positionY, 0);


		scaleX = 1f;
		scaleY = 1;
		transform.localScale = new Vector3 (scaleX, scaleY, 0);

	}
	
	// Update is called once per frame
	void Update () {


		//ajuste la longeur de la bar selon la quantité de vie qu'il reste
		scaleX = ((float)player.Vitality / (float)player.vitalityMax);

		transform.localScale = new Vector3 (scaleX, scaleY, 0);


	}
}
