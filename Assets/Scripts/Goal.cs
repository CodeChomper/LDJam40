using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour {

    Timer nextLevelTimer;
    [SerializeField]
    AudioSource goalSound;

    GameObject player;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");
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
            Player tmp = player.GetComponent<Player>();
            tmp.reachedGoal = true;
            goalSound.Play();
            nextLevelTimer = gameObject.AddComponent<Timer>();
            nextLevelTimer.SetTimeOut(1);
            nextLevelTimer.StartTimer();
        }
    }

}
