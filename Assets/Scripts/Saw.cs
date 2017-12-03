using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : MonoBehaviour {
    Animation anim;
    Timer restartTimer;

	// Use this for initialization
	void Start () {
        anim = gameObject.GetComponent<Animation>();
	}
	
	// Update is called once per frame
	void Update () {
		if(!anim.isPlaying && LevelController.levelIsPlaying)
        {
            anim.Play();
        }
        if(restartTimer && restartTimer.TimeUp())
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
