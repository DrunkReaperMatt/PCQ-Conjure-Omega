using UnityEngine;
using System.Collections;
using System;

public class CharacterHealt : MonoBehaviour {

	public int maxHealt = 100;
	public int vieCourante = 100;
	public Boolean visible = false;

	private Rect BarNoire;
	private Rect BarVerte;

	public float heigthHealtBar;
	public float positionXHealtBar;
	public float positionYHealtBar;

	private Texture HealtFull;


	// Use this for initialization
	void Start () {
	

	}
	
	// Update is called once per frame
	void Update () {
	


	}

	void OnGui() {


		//BarVerte = new Rect (-7, 7, maxHealt/10, 2);
		//BarNoire = BarVerte;

		heigthHealtBar = 2;

		positionXHealtBar = -7;

		positionYHealtBar = 7;




		//BarVerte.width = ((maxHealt - vieCourante) /10);



		//GUI.DrawTexture (Rect(positionXHealtBar, positionYHealtBar , maxHealt / 10, heigthHealtBar), HealtFull, ScaleMode.StretchToFill, false, 1.0);


	}

}
