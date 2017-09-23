using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class highJumpPlatform : MonoBehaviour {

	public float fuerzaSalto;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {}

	void OnCollisionEnter2D(Collision2D coll) {
		coll.rigidbody.velocity = new Vector2 (coll.rigidbody.velocity.x, fuerzaSalto);
	}
}
