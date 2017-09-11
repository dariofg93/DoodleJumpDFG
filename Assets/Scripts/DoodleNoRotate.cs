using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoodleNoRotate : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//RESTRINGIENDO ROTACION DEL JUGADOR

		Quaternion rotTemp = transform.rotation;
		rotTemp.z = 0; 

//		rotTemp = Quaternion.Euler (transform.rotation.x, transform.rotation.y, 0);

		transform.rotation = rotTemp;
	}
}
