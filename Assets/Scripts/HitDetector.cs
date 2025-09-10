using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitDetector : MonoBehaviour {

	public AudioClip scoreClip;

	private ParticleSystem ps;
	private BoxDisplay boxDisplay;
	private AttemptsRemaining attempts;
	private Camera mainCamera;

	void Awake()
	{
		ps = FindFirstObjectByType<ParticleSystem> ();
		boxDisplay = FindFirstObjectByType<BoxDisplay> ();
		attempts = FindFirstObjectByType<AttemptsRemaining> ();
		mainCamera = FindFirstObjectByType<Camera> ();
	}

	void OnTriggerExit(){
		var main = ps.main;
		if (gameObject.CompareTag("Large Box"))
		{
			Destroy(gameObject);
			main.startColor = Color.green;
			Instantiate(ps, transform.position, Quaternion.identity);
			attempts.missesRemaining++;
		}
		if (gameObject.CompareTag("Medium Box"))
        {
			Destroy (gameObject);
			main.startColor = Color.cyan;
			Instantiate (ps, transform.position, Quaternion.identity);
			attempts.missesRemaining++;
		}
		if (gameObject.CompareTag("Small Box"))
        {
			Destroy (gameObject);
			main.startColor = Color.blue;
			Instantiate (ps, transform.position, Quaternion.identity);
			attempts.missesRemaining++;
		}
		if (gameObject.CompareTag("Very Small Box"))
        {
			Destroy (gameObject);
			main.startColor = Color.yellow;
			Instantiate (ps, transform.position, Quaternion.identity);
			attempts.missesRemaining++;
		}
		boxDisplay.boxCount--;
		AudioSource.PlayClipAtPoint (scoreClip, mainCamera.transform.position);
	}

}
