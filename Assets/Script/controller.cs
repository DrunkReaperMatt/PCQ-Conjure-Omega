using UnityEngine;
using System.Collections;

public class controller : MonoBehaviour {
	public float speed = 10;
	public GameObject camera;

	private GameObject minion;

	// Use this for initialization
	void Start () {
		camera = GameObject.FindGameObjectWithTag("MainCamera");
		//minion = GameObject.GetComponent<GameController>();
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
			CameraControls track = camera.GetComponent<CameraControls>();

		}
	}
}
