using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {
    Timer restartTimer;
    [SerializeField]
    AudioSource botDeath;

    [SerializeField]
    Transform botDeatAnim;

    [SerializeField]
    float speed = 2;
    GameObject player;
    // Use this for initialization
    void Start () {
        player = GameObject.Find("Player");
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
            
            Instantiate(botDeatAnim, player.transform.position, player.transform.rotation);
            player.SetActive(false);
            botDeath.Play();
            restartTimer = gameObject.AddComponent<Timer>();
            restartTimer.SetTimeOut(1);
            restartTimer.StartTimer();
        }
    }
}
