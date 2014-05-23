using UnityEngine;
using System.Collections;

public class MyGameController : MonoBehaviour {

    private GameObject thePlayer;
    private float timer;
	// Use this for initialization
	void Start () {

        timer = 0f;
        thePlayer = GameObject.FindGameObjectsWithTag(Tag.player)[0];
	}
	
	// Update is called once per frame
    
	void Update () {
        timer += Time.deltaTime;
        
        if (timer > 4.0f)
        {
            thePlayer.GetComponent<Character>().SendMessage("ApplyDamage", new DamageCounter(null, 10));
            timer = 0f;
        }

	}
    


}
