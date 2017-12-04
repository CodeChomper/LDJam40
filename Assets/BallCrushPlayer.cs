﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCrushPlayer : MonoBehaviour {
    Timer restartTimer;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (restartTimer && restartTimer.TimeUp())
        {
            LevelController.Restart();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameObject player = GameObject.Find("Player");
            player.SetActive(false);
            restartTimer = gameObject.AddComponent<Timer>();
            restartTimer.SetTimeOut(1);
            restartTimer.StartTimer();
        }
    }
}
