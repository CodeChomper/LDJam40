using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour {

    Timer nextLevelTimer;

	// Use this for initialization
	void Start () {
   
	}
	
	// Update is called once per frame
	void Update () {
		if(nextLevelTimer && nextLevelTimer.TimeUp())
        {
            LevelController.nextLevel();
        }
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            nextLevelTimer = gameObject.AddComponent<Timer>();
            nextLevelTimer.SetTimeOut(1);
            nextLevelTimer.StartTimer();
        }
    }

}
