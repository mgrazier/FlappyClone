using UnityEngine;
using System.Collections;

public class KillZone : MonoBehaviour {

	public BoxCollider bc;
    public GameManager gm;

	// Use this for initialization
	void Start () {
		bc = GetComponent<BoxCollider> ();
        gm = FindObjectOfType<GameManager>().GetComponent<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		if (other.CompareTag("Player")) {
			other.gameObject.SetActive (false);
            gm.GameOver();
        }
	}

}
