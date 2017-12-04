using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Credits : MonoBehaviour {
    Timer textSwitch;
    string[] winMessage = new string[]
    {
        "",//2
        "Thank you so much!",//2
        "You are so smart,",//2
        "and you made me smart!",//2
        "Thank goodness I didn't get recycled.",//2.5
        ""//1
    };
    string[] failMessage = new string[]
    {
        "",
        "Well you blew it!",
        "I am no smarter than..",
        "One, Two, Three, Four, or Five.",
        "Now they are going to send me to reprogramming again!"
    };

    string[] creditText = new string[]
    {
        
        "Game Design",//1
        "Code",//1
        "3D Models",//1
        "Sounds",//1
        "Music",//1
        "EVERYTHING By:",//2
        "Jason Forsythe AKA",//2.5
        "CodeChomper",//2
        "",//1
        "Built for Ludum Dare #40",//3
        "In 72 Hours!",//2
        "I would love to hear your feedback!",//3
        "Thanks for playing!",//3
        "",//60
        "You must really like my song to listen to it for this long!"//1000
    };

    string[] intro = new string[21];

    float[] introTimes = new float[]
    {
        2f,
        2f,
        2f,
        2f,
        3.5f,
        1f,
        1f,
        1f,
        1f,
        1f,
        1f,
        2f,
        2.5f,
        2f,
        1f,
        3f,
        2f,
        3f,
        3f,
        60f,
        1f
    };

    Text t;

    int curPhrase = 0;

    // Use this for initialization
    void Start()
    {
        if(LevelController.TotalScore() >= 3f)
        {
            winMessage.CopyTo(intro, 0);
        }
        else
        {
            failMessage.CopyTo(intro, 0);
        }
        creditText.CopyTo(intro, winMessage.Length);
        textSwitch = gameObject.AddComponent<Timer>();
        textSwitch.SetTimeOut(2);
        textSwitch.StartTimer();
        t = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (textSwitch && textSwitch.TimeUp())
        {
            if (curPhrase < intro.Length - 1)
            {
                curPhrase++;
                textSwitch.SetTimeOut(introTimes[curPhrase]);
                textSwitch.Restart();
                t.text = intro[curPhrase];
            }
            else
            {
                textSwitch = null;
                //LevelController.nextLevel();
            }
        }
    }
}
