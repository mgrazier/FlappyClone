using UnityEngine;
using System.Collections;

public class KillZone : MonoBehaviour {

	public BoxCollider2D bc;
    public GameManager gm;
    public Animator anim;

	// Use this for initialization
	void Start () {
		bc = GetComponent<BoxCollider2D> ();
        gm = FindObjectOfType<GameManager>().GetComponent<GameManager>();
        anim = GameObject.FindGameObjectWithTag("Flash").GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.CompareTag("Player")) {
			other.gameObject.SetActive (false);
            anim.Play("Flash");
            //gm.GameOver();
        }
	}

}
