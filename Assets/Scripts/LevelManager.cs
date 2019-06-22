using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {


	void Start () {
		if (Application.loadedLevelName == "_Splash") {
			LoadStartFromSplash ();
		}
	}
	
	public void LoadLevel(string name){
		Application.LoadLevel (name);
	}

	public void LoadNextLevel() {
		Application.LoadLevel (Application.loadedLevel + 1);
	}
	public void LoadStartFromSplash() {
		Invoke ("LoadStart", 1.9f);
	}
	public void LoadStart(){
		Application.LoadLevel ("_Start");
	}
}
