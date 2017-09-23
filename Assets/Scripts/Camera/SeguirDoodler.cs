using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeguirDoodler : MonoBehaviour {

	public Transform doodler;
	private bool perdio = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (perdio) {
			seguirDoodler ();
		}
		else
			if(isFollowable()) seguirDoodler();

		verificarSiPerdio();
	}

	bool isFollowable(){
		return 	doodler.GetComponent<Rigidbody2D> ().velocity.y > 0.0f
									&&
				doodler.position.y >= transform.position.y;
	}

	void seguirDoodler(){
//		transform.position = new Vector3 (transform.position.x, doodler.position.y, transform.position.z);
		transform.localPosition = Vector3.MoveTowards(transform.localPosition,
			new Vector3 (transform.position.x, doodler.position.y, transform.position.z),
			2.0f);
	}

	void verificarSiPerdio(){
		if(!perdio)
			perdio = doodler.transform.position.y < transform.position.y - CameraProperties.limitYNegativo;
	}
}
