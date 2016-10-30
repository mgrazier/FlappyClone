using UnityEngine;
using System.Collections;

public class FlappyController : MonoBehaviour {

	public Rigidbody rb;
	public float startVelX = 1.0f;
    public float gravity = -10.0f;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		rb.velocity = new Vector3 (startVelX, 0f, 0f);
        rb.isKinematic = true;
        Physics.gravity = new Vector3(0, gravity, 0);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (rb.isKinematic) {
            transform.Translate(.05f, 0, 0);
        }
    }

    public void Flap()
    {
        if (rb.isKinematic) {
            rb.isKinematic = false;
        }
        rb.velocity = new Vector3(startVelX, 5f, 0f);
    }
}
