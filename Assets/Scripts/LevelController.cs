using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class LevelController{
    public static int deaths = 0;
    public static int moves = 0;


    private static string[] levels = new string[] {
        "Intro",
        "Tut1",
        "Tut2",
        "Tut3",
        "Tut4",
        "Credits"
    };
    private static string levelName;

    private static int curLevel;
    public static bool levelIsPlaying = false;

    private static int[] levelScores = new int[levels.Length];
    private static int[] levelPars = new int[]
    {
        0,  //Intro
        3,  //Tut1
        5,  //Tut2
        12, //Tut3
        6,  //Tut4
        0   //Credits
    };

    static LevelController()
    {
        levelName = SceneManager.GetActiveScene().name;
        for (int i=0; i<levels.Length; i++)
        {
            if(levels[i] == levelName)
            {
                curLevel = i;
                return;
            }
        }
    }

    public static void nextLevel()
    {
        if(curLevel > 0) SubmitScore();
        deaths = 0;
        moves = 0;
        levelIsPlaying = false;
        if (curLevel + 1 >= levels.Length)
        {
            curLevel = 0;
            SceneManager.LoadScene(curLevel);
        }
        else
        {
            SceneManager.LoadScene(++curLevel);
        }
    }

    public static void Restart()
    {
        deaths += 1;
        moves = 0;
        levelIsPlaying = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    static void SubmitScore()
    {
        int tempScore = 0;

        //if died and score above par one star
        if(deaths>0 && moves > levelPars[curLevel])
        {
            tempScore = 1;
        }

        //if score above par but did not die two stars
        if(moves > levelPars[curLevel] && deaths == 0)
        {
            tempScore = 2;
        }

        //if died and score below par three stars
        if(deaths > 0 && moves <= levelPars[curLevel])
        {
            tempScore = 3;
        }

        //if score below par and did not die four stars
        if(deaths == 0 && moves <= levelPars[curLevel])
        {
            tempScore = 4;
        }

        levelScores[curLevel] = tempScore;

        //Remove after debuging;
        TotalScore();

    }

    public static float TotalScore()
    {
        float totalScore = 0f;
        int i;
        //Starting at 1 and length -1 is to avoid counting
        //Intro and credits levels.
        for(i = 1; i<levelScores.Length - 1; i++)
        {
            totalScore += levelScores[i];
        }
        totalScore = totalScore / (i - 1);
        return totalScore;
    }
}
