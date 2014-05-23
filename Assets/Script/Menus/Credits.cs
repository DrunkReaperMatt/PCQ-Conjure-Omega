using UnityEngine;
using System.Collections;

public class Credits : MonoBehaviour {

	public int delaiEntreEcrans = 3;

	private GameObject gc1;  
	private GameObject gc2; 
	private GameObject gc3; 

	// Use this for initialization
	void Start () {
		Debug.Log ("Credits Start()");
		gc1 = GameObject.Find ("Credit1");
		gc2 = GameObject.Find ("Credit2");
		gc3 = GameObject.Find ("Credit3");

		StartCoroutine ( ShowCredits () );
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator ShowCredits(){
		Debug.Log ("ShowCredits()");

		 
		gc1.renderer.enabled = true;
		gc2.renderer.enabled = false;
		gc3.renderer.enabled = false;
		yield return new WaitForSeconds (delaiEntreEcrans);

		gc1.renderer.enabled = false;
		gc2.renderer.enabled = true;
		gc3.renderer.enabled = false;
		yield return new WaitForSeconds (delaiEntreEcrans);

		gc1.renderer.enabled = false;
		gc2.renderer.enabled = false;
		gc3.renderer.enabled = true;
		yield return new WaitForSeconds (delaiEntreEcrans);
	}
}
