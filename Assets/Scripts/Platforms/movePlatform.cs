using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movePlatform : MonoBehaviour {

	public float maxSpeed;
	private Vector3 velocityX;

	// Use this for initialization
	void Start () {
		velocityX = new Vector3(maxSpeed * Time.deltaTime, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 posX = transform.position;
		if (velocityX.x > 0.0f && transform.position.x > CameraProperties.limitX) {
			velocityX = new Vector3(maxSpeed * (-1) * Time.deltaTime, 0, 0);
		}

		if (velocityX.x < 0.0f && transform.position.x < CameraProperties.limitX * (-1)) {
			velocityX = new Vector3(maxSpeed * Time.deltaTime, 0, 0);
		}

		posX += velocityX;
		transform.position = posX;
	}
}
