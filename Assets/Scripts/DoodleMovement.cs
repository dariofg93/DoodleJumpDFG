using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoodleMovement : MonoBehaviour {

	public float maxSpeed = 15f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//MOVIMIENTO DEL JUGADOR

		Vector3 posX = transform.position;
		Vector3 velocityX = new Vector3(Input.GetAxis("Horizontal") * maxSpeed * Time.deltaTime, 0, 0);
		posX += velocityX;

		Quaternion rotTemp = transform.rotation;

		if (Input.GetAxis ("Horizontal") > 0)
			rotTemp = Quaternion.Euler (transform.rotation.x, 0, transform.rotation.z);
		else
			if (Input.GetAxis ("Horizontal") < 0) 
				rotTemp = Quaternion.Euler (transform.rotation.x, 180, transform.rotation.z);

		transform.rotation = rotTemp;
		transform.position = posX;
	}
}
