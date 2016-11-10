using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public Camera mainCamera;
	public GameObject playerCharacter;
    private FlappyController fc;

	// Use this for initialization
	void Start () {
		mainCamera = Camera.main;
		playerCharacter = GameObject.Find ("Flappy");
        fc = playerCharacter.GetComponent<FlappyController>();
	}
	
	// Update is called once per frame
	void Update () {
        if (fc.GetDashing()) {
            mainCamera.transform.position = new Vector3(playerCharacter.transform.position.x+3, 0f, -10f);
        } else {
            mainCamera.transform.position = new Vector3(playerCharacter.transform.position.x + 3, 0f, -10f);
        }
	}
}
