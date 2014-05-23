using UnityEngine;
using System.Collections;

public class controller : MonoBehaviour {
	public float speed = 10;
	public GameObject camera;

	// Use this for initialization
	void Start () {
		camera  = GameObject.FindGameObjectWithTag("MainCamera");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float moveV = Input.GetAxis("Vertical");
		float moveH = Input.GetAxis("Horizontal");
		rigidbody2D.velocity = new Vector2(moveH * speed, moveV * speed);
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.tag == "Trigger")
		{
			bool track = camera.GetComponent<CameraControls>().tracking;
			camera.GetComponent<CameraControls>().tracking = ( track == true) ? false : true;
			Destroy(col.gameObject);
			//Spawn Wave
		}
	}
}
