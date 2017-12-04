using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {
    Timer restartTimer;
    [SerializeField]
    AudioSource botDeath;

    [SerializeField]
    float speed = 2;
    
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        var tmpRotation = Quaternion.Euler(Random.rotation.x * 360, 0, 0);
        transform.rotation = Quaternion.Lerp(transform.rotation, tmpRotation, Time.time * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameObject player = GameObject.Find("Player");
            player.SetActive(false);
            botDeath.Play();
            restartTimer = gameObject.AddComponent<Timer>();
            restartTimer.SetTimeOut(1);
            restartTimer.StartTimer();
        }
    }
}
