using UnityEngine;
using System.Collections;

public class Parallax : MonoBehaviour {
	private float x;
	public int offset;
	public bool follow;


	// Use this for initialization
	void Start () {
		x = Camera.main.transform.position.x;
	}
	
	// Update is called once per frame
	void Update () {
		if (follow){
			transform.position = new Vector2((Camera.main.transform.position.x - x) / offset,
			Camera.main.transform.position.y);
		}else{
			transform.position = new Vector2((x - Camera.main.transform.position.x) / offset,
			Camera.main.transform.position.y);
		}

	}
}
