using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Commands : MonoBehaviour {
    
    public Queue<string> commands = new Queue<string>();
    Timer stepTimer;

    [SerializeField]
    GameObject player;

    [SerializeField]
    Text commandsText;

    Player playerScript;
    bool play = false;
   

	// Use this for initialization
	void Start () {
        playerScript = player.GetComponent<Player>();

        //This will be replaced by buttons pushing commands into stack
        stepTimer = gameObject.AddComponent<Timer>();
        stepTimer.SetTimeOut(1.2f);
    }
	
	// Update is called once per frame
	void Update () {
        UpdateCommandText();

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
        stepTimer.StartTimer();
        this.play = true;
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
