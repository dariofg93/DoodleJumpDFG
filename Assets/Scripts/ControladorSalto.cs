using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorSalto : MonoBehaviour {

	public float fuerzaSalto = 100f;
	public bool enSuelo = true;
	public Transform comprobadorSuelo;
	private float comprobadorRadio = 0.12f;
	public LayerMask mascaraSuelo;

	// Use this for initialization
	void Start () {
		
	}

	void FixedUpdate(){
		enSuelo = Physics2D.OverlapCircle (comprobadorSuelo.position, comprobadorRadio, mascaraSuelo);
	}
	
	// Update is called once per frame
	void Update () {
		Rigidbody2D rigidBody = GetComponent<Rigidbody2D> ();
		
		if (enSuelo && rigidBody.velocity.y < 0.0f) {
			rigidBody.velocity = new Vector2 (rigidBody.velocity.x, fuerzaSalto);
		}

		Physics2D.IgnoreLayerCollision (8, 9, (rigidBody.velocity.y > 0.0f));
	}
}
