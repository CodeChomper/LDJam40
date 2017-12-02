using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Comands : MonoBehaviour {
    
    public Queue<string> commands = new Queue<string>();
    Timer stepTimer;

    [SerializeField]
    GameObject player;

    Player playerScript;
    bool play = false;
   

	// Use this for initialization
	void Start () {
        playerScript = player.GetComponent<Player>();

        //This will be replaced by buttons pushing commands into stack
        commands.Enqueue("up");
        commands.Enqueue("up");
        commands.Enqueue("right");
        commands.Enqueue("up");
        stepTimer = gameObject.AddComponent<Timer>();
        stepTimer.SetTimeOut(1.5f);
    }
	
	// Update is called once per frame
	void Update () {
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
                    case "up":
                        playerScript.MoveForward();
                        break;
                    case "right":
                        playerScript.TurnRight();
                        break;
                }
            }
        }
		
	}

    public void Play()
    {
        stepTimer.StartTimer();
        this.play = true;
    }
}
