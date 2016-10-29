using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {

    public Text scoreText;
    private int score;

	// Use this for initialization
	void Start () {
        score = 0;
        UpdateScore();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void IncreaseScore()
    {
        score++;
        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }
}
