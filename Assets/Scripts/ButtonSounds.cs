using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSounds : MonoBehaviour {

    [SerializeField]
    AudioSource[] buttonSounds;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PlaySound()
    {
        int index = (int)Mathf.Round(Random.Range(0, buttonSounds.Length - 1));
        buttonSounds[index].Play();
    }

}
