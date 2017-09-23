using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {

	public GameObject[] prefab = new GameObject[4];
	public Transform camara;

	private float currentCamaraPos = 0f;
	private int maxLevel = 3;
	private List<GameObject> platforms = new List<GameObject> ();

	//Cada lista gestiona las probabilidades de cada plataforma por nivel
	private static float[] probs1 = new float[] {0.75f,0.50f,0.25f,0.15f};	//normal
	private static float[] probs2 = new float[] {0.12f,0.15f,0.25f,0.30f};	//broken
	private static float[] probs3 = new float[] {0.08f,0.25f,0.35f,0.35f};	//move
	private static float[] probs4 = new float[] {0.05f,0.10f,0.15f,0.20f};	//highJump

	//Lista que gestiona todas las listas de probabilidades
	private ProbabilitiesManager probsManager = new ProbabilitiesManager(probs1,probs2,probs3,probs4);

	// Use this for initialization
	void Start () {
		var sequence = System.Linq.Enumerable.Range(-3, 10);
		foreach(int n in sequence) 
			createPlatform (n * 3f);
	}
	
	// Update is called once per frame
	void Update () {
		if (currentCamaraPos + 3f < camara.position.y) {
			createPlatform (camara.position.y + 18f);
			currentCamaraPos = camara.position.y;
		}

		deleteOlderPlatform ();
	}

	void createPlatform (float position){
		float x = Random.Range ( CameraProperties.limitX * (-1), CameraProperties.limitX );
		Vector3 pos = new Vector3 (x, position, -1);

		int wichPlatform = selectPlatform(takeProbabilities());
		GameObject platform = Instantiate (prefab[wichPlatform], pos, camara.rotation) as GameObject;
		platforms.Add (platform);
	}

	void deleteOlderPlatform(){
		for(int current = 0; current != platforms.Count-1; current++){
			GameObject p = platforms [current];

			if (p.transform.position.y < camara.position.y - CameraProperties.limitYNegativo) {
				platforms.RemoveAt (current);
				Destroy (p);
				current--;
			}
		}
	}

	float[] takeProbabilities(){
		GameObject score = GameObject.Find("Score");
		Score scoreComponent = score.GetComponent<Score> ();

		return probsManager.probabilitiesPlatform(scoreComponent.totalScore(),maxLevel);
	}

	int selectPlatform(float[] probs){
		float total = 0;
		foreach (float elem in probs)
			total += elem;

		float randomPoint = Random.value * total;

		for (int i= 0; i < probs.Length; i++) {
			if (randomPoint < probs[i]) 
				return i;
			else
				randomPoint -= probs[i];
		}

		return probs.Length - 1;
	}
}
