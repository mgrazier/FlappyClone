using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {

    public GameObject flappy;
    private FlappyController flappyController;
    public Text scoreText;
    public int score;
    private GameObject startCanvas;
    private GameObject gameOverCanvas;
    private GameObject obstacleSpawner;
    private ObstacleSpawner os;
    private Rigidbody flappyRB;
    private bool gameStarted = false;
    private ScoreCounter sc;
    private Animator anim;

	// Use this for initialization
	void Start () {
        flappy = GameObject.Find("Flappy");
        flappyController = flappy.GetComponent<FlappyController>();
        flappyRB = flappy.GetComponent<Rigidbody>();
        startCanvas = GameObject.Find("StartCanvas");
        gameOverCanvas = GameObject.Find("GameOverCanvas");
        gameOverCanvas.SetActive(false);
        obstacleSpawner = GameObject.Find("ObstacleSpawner");
        os = obstacleSpawner.GetComponent<ObstacleSpawner>();
        sc = gameOverCanvas.GetComponent<ScoreCounter>();

        score = 0;
        UpdateScore();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.anyKeyDown) {
            if (!gameStarted) {
                gameStarted = true;
                HideStartMenu();
                os.StartSpawner();
            }
            flappyController.Flap();
        }
	}

    public void IncreaseScore()
    {
        score++;
        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.text = score.ToString();
    }

    void HideStartMenu()
    {
        startCanvas.SetActive(false);
    }

    public IEnumerator GameOver()
    {
        yield return new WaitForSeconds(.25f);
        gameOverCanvas.SetActive(true);
        sc.StartCoroutine("CountTo", score);
        Debug.Log("Score: " + score);
        yield return null;
    }
}
