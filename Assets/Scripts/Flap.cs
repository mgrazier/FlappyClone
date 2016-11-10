using UnityEngine;
using System.Collections;

public class Flap : MonoBehaviour {

    Rigidbody2D rb;
    FlappyController fc;


	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        fc = GetComponent<FlappyController>();
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKeyDown(KeyCode.Mouse0)) {
            UseFlap();
        }
	}

    public void UseFlap()
    {
        if (rb.isKinematic) {
            rb.isKinematic = false;
        }
        if (fc.GetDashing() == false) {
            rb.velocity = new Vector3(fc.startVelX, 5f, 0f);
        }
    }

}
