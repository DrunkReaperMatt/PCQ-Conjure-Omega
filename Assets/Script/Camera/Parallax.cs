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
			transform.position = new Vector3((Camera.main.transform.position.x - x) / offset,
			transform.position.y,
			transform.position.z);
		}else{
			transform.position = new Vector3((x - Camera.main.transform.position.x) / offset,
			transform.position.y,
			transform.position.z);
		}

	}
}
