using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class AttemptsRemaining : MonoBehaviour {

	private Text attemptsRemainingDisplay;
	public int missesRemaining;
	private LevelManager levelManager;
	public static int totalScore;

	void Start()
	{
		levelManager = FindFirstObjectByType<LevelManager>();
		attemptsRemainingDisplay = GetComponent<Text>();
		attemptsRemainingDisplay.text = missesRemaining.ToString();
    }

	public void UpdateDisplay()
	{
		Debug.Log(missesRemaining.ToString());
		attemptsRemainingDisplay.text = missesRemaining.ToString();
		if (missesRemaining <= 0)
		{
			levelManager.LoadLose();
		}
	}
}
