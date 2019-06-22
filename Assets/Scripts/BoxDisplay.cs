using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoxDisplay : MonoBehaviour {

	public int boxCount;

	private Text boxDisplay;
	private LevelManager levelManager;

	void Start () {
		boxDisplay = GetComponent<Text> ();
		levelManager = FindObjectOfType<LevelManager> ();

		CountDisplay ();
		BoxUpdate ();
	}
	
	void Update () {
		CountDisplay ();
		NextLevelLoaded ();
	}
	void BoxUpdate(){
		foreach (HitDetector hit in GameObject.FindObjectsOfType<HitDetector>()) {
			boxCount++;
		}
	}
	void CountDisplay() {
		boxDisplay.text = boxCount.ToString ();
	}
	void NextLevelLoaded () {
		if (boxCount <= 0) {
			levelManager.LoadNextLevel ();
		}
	}
}
