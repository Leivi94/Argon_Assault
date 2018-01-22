using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour {


    int score;
    Text scoretext;
        
	// Use this for initialization
	void Start () {
        scoretext = GetComponent<Text>();
        scoretext.text = score.ToString();
	}

    //CHANGES A
    public void ScoreHit(int EnemyScore)
    {
        score = score + EnemyScore;
    }
}
