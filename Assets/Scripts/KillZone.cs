using UnityEngine;
using System.Collections;

public class KillZone : MonoBehaviour {

	public BoxCollider bc;
    public GameManager gm;
    public Animator anim;

	// Use this for initialization
	void Start () {
		bc = GetComponent<BoxCollider> ();
        gm = FindObjectOfType<GameManager>().GetComponent<GameManager>();
        anim = GameObject.FindGameObjectWithTag("Flash").GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		if (other.CompareTag("Player")) {
			other.gameObject.SetActive (false);
            anim.Play("Flash");
            //gm.GameOver();
        }
	}

}
