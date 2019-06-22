using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttemptsRemaining : MonoBehaviour {

	private Text attemptsRemainingDisplay;
	public int missesRemaining;
	private LevelManager levelManager;
	public static int totalScore;

	void Start () {
		attemptsRemainingDisplay = GetComponent<Text> ();
		attemptsRemainingDisplay.text = missesRemaining.ToString ();
		levelManager = FindObjectOfType<LevelManager> ();
	}
	
	void Update () {
		updateDisplay ();
		GameLost ();
	}
	void GameLost() {
		if (missesRemaining <= 0) {
			levelManager.LoadLevel ("_Lose");
		}
	}

	void updateDisplay (){
		attemptsRemainingDisplay.text = missesRemaining.ToString ();
	}
}
