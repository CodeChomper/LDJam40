using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FallTrigger : MonoBehaviour {
    [SerializeField]
    AudioSource robotDie;

    Timer restartTimer;
	// Use this for initialization
	void Start () {
        restartTimer = gameObject.AddComponent<Timer>();
        restartTimer.SetTimeOut(1f);

	}
	
	// Update is called once per frame
	void Update () {
		if(restartTimer && restartTimer.TimeUp())
        {
            
            LevelController.Restart();
        }
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            robotDie.Play();
            restartTimer.StartTimer();
        }
    }
}
