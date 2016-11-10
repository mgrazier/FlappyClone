using UnityEngine;
using System.Collections;

public class Dash : MonoBehaviour {

    Rigidbody2D rb;
    FlappyController fc;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        fc = GetComponent<FlappyController>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space)) {
            StartCoroutine("UseDash");
        }
    }

    public IEnumerator UseDash()
    {
        float dashTime = .25f;
        float startVelX = rb.velocity.x;
        Vector3 oldGravity = Physics.gravity;
        Physics.gravity = Vector3.zero;
        rb.velocity = Vector3.zero;
        fc.SetDashing(true);

        if (rb.isKinematic) {
            rb.isKinematic = false;
        }
        while (fc.GetDashing()) {
            rb.AddForce(new Vector3(500f, 0, 0));
            yield return new WaitForSeconds(dashTime);
            rb.velocity = new Vector3(startVelX, 0, 0);
            fc.SetDashing(false);
        }

        Physics.gravity = oldGravity;
        yield return null;
    }
}
