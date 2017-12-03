using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroText : MonoBehaviour {
    Timer textSwitch;

    string[] intro = new string[]
    {
        "",
        "Hi, I am Six...",
        "There were five others before me,",
        "but let's not worry about what happened to them.",
        "I need your help!",
        "My AI chip needs reprogramming.",
        "Train my AI chip by programming routines to help me pass the test levels.",
        "Complete the levels in as few moves as possible.",
        "The MORE moves you use the WORSE my AI becomes.",
        "Now hurry, there is no room for dumb robots.",
        "Just ask One, Two, Three, Four, or Five...."
    };
    float[] introTimes = new float[]
    {
        2.0f,
        2.0f,
        2.5f,
        3f,
        2f,
        2.5f,
        5f,
        3.5f,
        3.5f,
        4f,
        6f
    };

    Text t;

    int curPhrase = 0;

	// Use this for initialization
	void Start () {
        textSwitch = gameObject.AddComponent<Timer>();
        textSwitch.SetTimeOut(2);
        textSwitch.StartTimer();
        t = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		if(textSwitch && textSwitch.TimeUp())
        {
            if(curPhrase < intro.Length-1)
            {
                curPhrase++;
                textSwitch.SetTimeOut(introTimes[curPhrase]);
                textSwitch.Restart();
                t.text = intro[curPhrase];
            }
            else
            {
                textSwitch = null;
                LevelController.nextLevel();
            }
        }
	}
}
