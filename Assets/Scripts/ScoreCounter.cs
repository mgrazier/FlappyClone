using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour {

    public float duration = 0.5f;
    int score = 0;
    Text scoreText;

	// Use this for initialization
	void Start () {
        scoreText = GameObject.FindGameObjectWithTag("CurrentScore").GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    IEnumerator CountTo (int target)
    {
        yield return new WaitForSeconds(.3f);
        int start = score;
        for (float timer = 0; timer < duration; timer += Time.deltaTime) {
            float progress = timer / duration;
            scoreText.text = (Mathf.RoundToInt(Mathf.Lerp(start, target, progress))).ToString();
            yield return null;
        }
    }
}
