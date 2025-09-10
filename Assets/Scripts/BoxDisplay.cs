using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class BoxDisplay : MonoBehaviour {
	public int boxCount;
	private Text boxDisplay;
	private LevelManager levelManager;

    void Awake()
    {
		boxDisplay = GetComponent<Text>();
    }

    [System.Obsolete]
    void Start () {
		levelManager = FindFirstObjectByType<LevelManager>();

		CountDisplay ();
		BoxUpdate ();
	}
	
	void Update () {
		CountDisplay ();
		NextLevelLoaded ();
	}

    [System.Obsolete]
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
			levelManager.LoadNextLevel();
		}
	}
}
