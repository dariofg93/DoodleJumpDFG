using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportOppositeSide : MonoBehaviour {

	// Use this for initialization
	void Start () {}
	
	// Update is called once per frame
	void Update () {
		if (Mathf.Abs (transform.position.x) > CameraProperties.limitX + 2.5f) {
			Vector2 posTemp = transform.position;

			if(posTemp.x > 0)
				posTemp.x = (posTemp.x - 1.5f) * (-1);
			else 
				posTemp.x = (posTemp.x + 1.5f) * (-1);

			transform.position = posTemp;
		}
	}
}
