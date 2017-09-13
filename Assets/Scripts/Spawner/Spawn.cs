using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {

	public GameObject prefab;
	public Transform camara;
	private float currentCamaraPos = 0f;

	// Use this for initialization
	void Start () {
		var sequence = System.Linq.Enumerable.Range(-3, 10);

		foreach(int n in sequence){
			float x = Random.Range (-14f, 14f);
			Vector3 pos = new Vector3 (x, n * 3f, -1);

			GameObject platform = Instantiate (prefab, pos, camara.rotation) as GameObject;
			Destroy (platform,10f); //Quitar si no es necesario
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (currentCamaraPos + 3f < camara.position.y) {
			float x = Random.Range (-14f, 14f);
			Vector3 pos = new Vector3 (x, camara.position.y + 18f, -1);

			GameObject platform = Instantiate (prefab, pos, camara.rotation) as GameObject;
			Destroy (platform,10f); //Quitar si no es necesario
			currentCamaraPos = camara.position.y;
		}
	}
}
