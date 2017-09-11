using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeguirDoodler : MonoBehaviour {

	public Transform doodler;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(isFollowable())
			transform.position = new Vector3 (transform.position.x, doodler.position.y, transform.position.z);
	}

	bool isFollowable(){
		return 	doodler.GetComponent<Rigidbody2D> ().velocity.y > 0.0f
									&&
				doodler.position.y >= transform.position.y;
	}
}
