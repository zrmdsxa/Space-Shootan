using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour {
    int score = 0;

	// Use this for initialization
	void Start () {
        updateHUD();
	}
	
	// Update is called once per frame
	void Update () {

    }

    public void setScore(int s)
    {
        score = s;
        updateHUD();
    }

    public void updateHUD()
    {
        GetComponent<Text>().text = string.Format("{0}", score);

    }
}
