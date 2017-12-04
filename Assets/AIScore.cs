using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIScore : MonoBehaviour {
    [SerializeField]
    RectTransform progressBar;

    float maxWidth = 200f;
    const float HEIGHT = 30f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float ratio = LevelController.TotalScore() / 4;
        progressBar.sizeDelta = new Vector2(maxWidth * ratio, HEIGHT);
	}
}
