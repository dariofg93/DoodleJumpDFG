using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

	private float alturaMaxima;
	private Score score;

	// Use this for initialization
	void Start () {
		score = GameObject.Find ("Score").GetComponent<Score> ();
		alturaMaxima = GetComponent<Transform>().position.y;
	}
	
	// Update is called once per frame
	void Update () {
		float alturaActual = GetComponent<Transform>().position.y;

		if (alturaMaxima < alturaActual) {
			score.addScore (alturaActual - alturaMaxima);
			alturaMaxima = alturaActual;
		}
	}
}
