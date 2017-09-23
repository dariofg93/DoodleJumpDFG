using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brokenPlatform : MonoBehaviour {

	private Animator animacion;
	private bool seRompio;

	public float fallSpeed;

	// Use this for initialization
	void Start () {
		animacion = GetComponent<Animator> ();
		seRompio = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (seRompio) {
			Vector3 posY = transform.position;
			Vector3 velocityY = new Vector3 (0, -fallSpeed * Time.deltaTime, 0);
			posY += velocityY;
			transform.position = posY;
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
			animacion.SetBool ("rompio", true);

			seRompio = true;
	}
}
