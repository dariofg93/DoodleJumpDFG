using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour {

	private float score = 0;
	private TextMesh showText = null;
	public float scoreMultiplier;

	// Use this for initialization
	void Start () {
		showText = GetComponent<TextMesh> ();
	}
	
	// Update is called once per frame
	void Update () {
		showText.text = "Score: " + (int) (score * scoreMultiplier);
	}

	public void addScore(float valorAgregado){
		score += valorAgregado;
	}
}
