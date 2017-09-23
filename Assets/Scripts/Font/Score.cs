using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour {

	private float scorePoints = 0;
	private TextMesh showText = null;
	public float scoreMultiplier;

	// Use this for initialization
	void Start () {
		showText = GetComponent<TextMesh> ();
	}
	
	// Update is called once per frame
	void Update () {
		showText.text = "Score: " + (int) totalScore();
	}

	public float totalScore() {
		return scorePoints * scoreMultiplier;
	}

	public void addScore(float valorAgregado){
		scorePoints += valorAgregado;
	}
}
