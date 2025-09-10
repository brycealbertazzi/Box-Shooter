using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(LevelManager))]
[RequireComponent(typeof(Text))]
public class AttemptsRemaining : MonoBehaviour {

	private Text attemptsRemainingDisplay;
	public int missesRemaining;
	private LevelManager levelManager;
	public static int totalScore;

	void Awake()
	{
		levelManager = FindFirstObjectByType<LevelManager>();
		attemptsRemainingDisplay = GetComponent<Text>();
	}

	void Start () {
		attemptsRemainingDisplay.text = missesRemaining.ToString();
	}
	
	void Update () {
		UpdateDisplay ();
		GameLost ();
	}
	void GameLost() {
		if (missesRemaining <= 0) {
			levelManager.LoadLevelWithDelay("_Lose");
		}
	}

	void UpdateDisplay (){
		attemptsRemainingDisplay.text = missesRemaining.ToString();
	}
}
