using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour {
    float seconds = 1;
    float timeElapsed = 0;
    bool start = false;
    bool timeUp = false;
    

    public void SetTimeOut(float seconds)
    {
        this.seconds = seconds;
    }

    public void StartTimer()
    {
        start = true;
    }

    public bool TimeUp()
    {
        return this.timeUp;
    }

    public void Restart()
    {
        this.timeUp = false;
        this.timeElapsed = 0;
        this.start = true;
    }

    // Update is called once per frame
    void Update ()
    {
        if (this.start)
        {
            timeElapsed += Time.deltaTime;
            if(timeElapsed >= seconds)
            {
                this.start = false;
                this.timeUp = true;
            }
        }
		
	}
}
