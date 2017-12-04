using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Commands : MonoBehaviour {
    
    public Queue<string> commands = new Queue<string>();
    Timer stepTimer;
    Timer restartTimer;

    [SerializeField]
    GameObject player;

    [SerializeField]
    Text commandsText;

    [SerializeField]
    GameObject btnGroup;

    [SerializeField]
    AudioSource restartSound;

    Player playerScript;
    bool play = false;
   

	// Use this for initialization
	void Start () {
        playerScript = player.GetComponent<Player>();
        stepTimer = gameObject.AddComponent<Timer>();
        stepTimer.SetTimeOut(0.75f);
    }
	
	// Update is called once per frame
	void Update () {
        UpdateCommandText();
        if (restartTimer)
        {
            if (restartTimer.TimeUp())
            {
                LevelController.Restart();
            }
        }
        if (stepTimer.TimeUp())
        {
            stepTimer.Restart();
            if (this.play)
            {
                string curStep = "";
                print(commands.Count);

                if (commands.Count > 0)
                {
                    curStep = commands.Dequeue();

                }
                else
                {
                    if(!player.GetComponent<Player>().reachedGoal) restartSound.Play();
                    restartTimer = gameObject.AddComponent<Timer>();
                    restartTimer.SetTimeOut(2);
                    restartTimer.StartTimer();
                    this.play = false;
                }

                switch (curStep)
                {
                    case "MoveForward()":
                        playerScript.MoveForward();
                        break;
                    case "TurnRight()":
                        playerScript.TurnRight();
                        break;
                    case "TurnLeft()":
                        playerScript.TurnLeft();
                        break;
                }
            }
        }
		
	}

    void UpdateCommandText()
    {
        if (!commandsText) return;
        commandsText.text = "";

        if (commands.Count <= 0)
        {
            return;
        }
        else
        {
            foreach(string command in commands)
            {
                commandsText.text += command + "\n";
            }
        }
    }

    public void Play()
    {
        LevelController.moves = commands.Count;
        stepTimer.StartTimer();
        this.play = true;
        btnGroup.SetActive(false);
        LevelController.levelIsPlaying = true;
    }

    public void MoveForward()
    {
        this.commands.Enqueue("MoveForward()");
        
    }

    public void TurnRight()
    {
        this.commands.Enqueue("TurnRight()");
    }

    public void TurnLeft()
    {
        this.commands.Enqueue("TurnLeft()");
    }

    public void Wait()
    {
        this.commands.Enqueue("Wait()");
    }
}
