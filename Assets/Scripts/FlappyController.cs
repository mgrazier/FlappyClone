using UnityEngine;
using System.Collections;

public class FlappyController : MonoBehaviour {

	public Rigidbody2D rb;
	public float startVelX = 1.0f;
    public float gravity = -10.0f;

    private bool isDashing;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		rb.velocity = new Vector3 (startVelX, 0f, 0f);
        rb.isKinematic = true;
        Physics.gravity = new Vector3(0, gravity, 0);
        isDashing = false;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (rb.isKinematic) {
            transform.Translate(.05f, 0, 0);
        }
    }

    void Update()
    {
    }




    public bool GetDashing()
    {
        return isDashing;
    }

    public void SetDashing(bool newIsDashing)
    {
        isDashing = newIsDashing;
    }
}
