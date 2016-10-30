using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public Camera mainCamera;
	public GameObject playerCharacter;

	// Use this for initialization
	void Start () {
		mainCamera = Camera.main;
		playerCharacter = GameObject.Find ("Flappy");
	}
	
	// Update is called once per frame
	void Update () {
		mainCamera.transform.position = new Vector3(playerCharacter.transform.position.x + 3, 0f, -10f);
	}
}
