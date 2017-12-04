using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTrap : MonoBehaviour {
    [SerializeField]
    GameObject laserBeam;

    [SerializeField]
    float laserPulseTime = 1;

    Timer laserTimer;

    [SerializeField]
    bool laserActive = true;

    AudioSource laserSound;
	// Use this for initialization
	void Start () {
        laserSound = gameObject.GetComponent<AudioSource>();
        laserTimer = gameObject.AddComponent<Timer>();
        laserTimer.SetTimeOut(laserPulseTime);
        laserTimer.StartTimer();
	}
	
	// Update is called once per frame
	void Update () {
        if(laserTimer && laserTimer.TimeUp())
        {
            laserActive = !laserActive;
            laserBeam.SetActive(laserActive);
            if (laserActive)
            {
                laserSound.Play();
            }
            else
            {
                laserSound.Stop();
            }
            laserTimer.Restart();
        }
		
	}
}
