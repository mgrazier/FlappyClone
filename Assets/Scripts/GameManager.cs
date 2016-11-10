using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Advertisements;

public class GameManager : MonoBehaviour {

    public GameObject flappy;
    
    private FlappyController flappyController;
    private AdManager adManager;
    public Text scoreText;
    public int score;
    private GameObject startCanvas;
    private GameObject gameOverCanvas;
    private GameObject obstacleSpawner;
    private ObstacleSpawner os;
    private Rigidbody2D flappyRB;
    private bool gameStarted = false;
    private ScoreCounter sc;
    private Animator anim;
    private int playCount;

    // Serialize private fields
    //  instead of making them public.
    [SerializeField]
    string iosGameId;
    [SerializeField]
    string androidGameId;
    [SerializeField]
    bool enableTestMode;

    // Use this for initialization
    void Start () {
        adManager = FindObjectOfType<AdManager>();

        GetScore(); 
        Debug.Log("playCount: " + playCount);
        Time.timeScale = 0;
        if (playCount > 3) {
            int randomChance = Random.Range(0, 2);
            Debug.Log(randomChance);
            if (randomChance == 1) {
                adManager.ShowStandardVideoAd();
                playCount = 0;
            }
        }
        Time.timeScale = 1;

        flappy = GameObject.Find("Flappy");
        flappyController = flappy.GetComponent<FlappyController>();
        flappyRB = flappy.GetComponent<Rigidbody2D>();
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
        if (!gameStarted) {
            gameStarted = true;
            HideStartMenu();
            os.StartSpawner();
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

    void SaveScore()
    {
        PlayerPrefs.SetInt("PlayCount", playCount);
    }
    
    void GetScore()
    {
        playCount = PlayerPrefs.GetInt("PlayCount");
    }

    void HideStartMenu()
    {
        startCanvas.SetActive(false);
    }

    public IEnumerator GameOver()
    {
        playCount++;
        SaveScore();
        yield return new WaitForSeconds(.25f);
        gameOverCanvas.SetActive(true);
        sc.StartCoroutine("CountTo", score);
        Debug.Log("Score: " + score);
        yield return null;
    }
}
