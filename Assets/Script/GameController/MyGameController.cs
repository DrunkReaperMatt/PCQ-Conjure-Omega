﻿using UnityEngine;
using System.Collections;

public class MyGameController : MonoBehaviour {

    private GameObject thePlayer;
    private float timer;
	// Use this for initialization
	void Start () {
        Debug.Log("The hunt has began");
        timer = 0f;
        thePlayer = GameObject.FindGameObjectsWithTag(Tag.player)[0];
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;

        if (timer == 3.0f)
        {
            thePlayer.SendMessage("ReceiveDamage", new DamageCounter(null, 100));
            timer = 0f;
        }
	}
}