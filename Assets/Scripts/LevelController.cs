using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class LevelController{
    [SerializeField]
    private static string[] levels = new string[] {
        "Tut1",
        "Tut2",
        "Tut3",
        "Tut4"};
    private static string levelName;

    private static int curLevel;
    public static bool levelIsPlaying = false;

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
        levelIsPlaying = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
