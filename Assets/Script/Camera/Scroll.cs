using UnityEngine;
using System.Collections;

public class Scroll : MonoBehaviour {
	public float speed = 0;
	public float offset = 1;

	public bool Follow;
	private float X;


	// Use this for initialization
	void Start () {
		X = Camera.current.transform.position.x;
	}
	
	// Update is called once per frame
	void Update () {
		//renderer.material.mainTextureOffset = new Vector2(Time.time * speed,0);
		render();
	}

	public void render(){
		if (Follow){
			transform.position = new Vector3((Camera.current.transform.position.x - X) / offset,
			Camera.current.transform.position.y,
			Camera.current.transform.position.z);
		}else{
			transform.position = new Vector3((X - Camera.current.transform.position.x) / offset,
			                                 Camera.current.transform.position.y,
			                                 Camera.current.transform.position.z);
		}
	}
}
