using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ProbabilitiesManager{

	private float[][] probabilites;
	private float[] scorePerLevel;
	private float[] currentProbabilities;
	private int currentLevel;
	
	public ProbabilitiesManager(params float[][] probsList)
	{
		currentLevel = 0;
		scorePerLevel = new float[]{200f,350f,500f,1000f};
		probabilites = probsList;
		currentProbabilities = getProbabilities();
	}

	float[] getProbabilities(){
		float[] probs = new float[probabilites.Length];

		for (int i = 0; i < probabilites.Length; i++) {
			probs [i] = probabilites[i][currentLevel];
		}

		return probs;
	}

	public float[] probabilitiesPlatform(float score, int maxLevel){
		
		if (currentLevel <= maxLevel && score > scorePerLevel [currentLevel]) {
			if (currentLevel != maxLevel) currentLevel++;
			currentProbabilities = getProbabilities();	
		}

		return currentProbabilities;
	}
}