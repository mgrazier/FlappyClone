using UnityEngine;
using System.Collections;

public class ObstacleManager : MonoBehaviour {

    private GameObject flappy;
    private GameManager gm;

    private bool scored = false;

	// Use this for initialization
	void Start () {
        flappy = GameObject.Find("Flappy");
        gm = GameManager.FindObjectOfType<GameManager>();
        //Time.timeScale = 0;
	}
	
	// Update is called once per frame
	void Update () {
	    if (flappy.transform.position.x > transform.position.x && !scored) {
            scored = true;
            gm.IncreaseScore();
        }
	}
}
