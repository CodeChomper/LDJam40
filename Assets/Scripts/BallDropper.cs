using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDropper : MonoBehaviour {

    [SerializeField]
    Transform ball;

    [SerializeField]
    float dropDelay = 2f;

    Timer ballDropTimer;

	// Use this for initialization
	void Start () {
        ballDropTimer = gameObject.AddComponent<Timer>();
        ballDropTimer.SetTimeOut(dropDelay);
        ballDropTimer.StartTimer();
        Instantiate(ball, transform);
    }
	
	// Update is called once per frame
	void Update () {
		if(ballDropTimer && ballDropTimer.TimeUp())
        {
            ballDropTimer.Restart();
            Instantiate(ball, transform);
        }
	}
}
