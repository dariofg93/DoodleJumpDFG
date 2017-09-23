using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorSalto : MonoBehaviour {

	public float fuerzaSalto = 100f;
	public Transform comprobadorSuelo;
	public LayerMask mascaraSuelo;

	private float comprobadorRadio = 0.12f;
	private bool enSuelo = true;
	private Animator animacion;

	// Use this for initialization
	void Start () {
		animacion = GetComponent<Animator> ();
	}

	void FixedUpdate(){
		enSuelo = Physics2D.OverlapCircle (comprobadorSuelo.position, comprobadorRadio, mascaraSuelo);
		animacion.SetBool ("enSuelo", enSuelo && GetComponent<Rigidbody2D>().velocity.y < 0.0f);
	}
	
	// Update is called once per frame
	void Update () {
		Rigidbody2D rigidBody = GetComponent<Rigidbody2D> ();
		rigidBody.freezeRotation = true;
		if (enSuelo && rigidBody.velocity.y < 0.0f || rigidBody.velocity.y == 0.0f){
			rigidBody.velocity = new Vector2 (rigidBody.velocity.x, fuerzaSalto);
		}

		Physics2D.IgnoreLayerCollision (8, 9, (rigidBody.velocity.y > 0.0f));
		Physics2D.IgnoreLayerCollision (10, 9, (rigidBody.velocity.y > 0.0f));
		Physics2D.IgnoreLayerCollision (11, 9, (rigidBody.velocity.y > 0.0f));
	}
}
