using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitDetector : MonoBehaviour {

	public AudioClip scoreClip;

	private Ball ball;
	private ParticleSystem particleSystem;
	private BoxDisplay boxDisplay;
	private AttemptsRemaining attempts;
	private Camera mainCamera;

	void Start () {
		ball = FindObjectOfType<Ball> ();
		particleSystem = FindObjectOfType<ParticleSystem> ();
		boxDisplay = FindObjectOfType<BoxDisplay> ();
		attempts = FindObjectOfType<AttemptsRemaining> ();
		mainCamera = FindObjectOfType<Camera> ();
	}

	void OnTriggerExit(){
		if (gameObject.tag == "Large Box"){
			Destroy (gameObject);
			particleSystem.startColor = Color.green;
			Instantiate (particleSystem, transform.position, Quaternion.identity);
			attempts.missesRemaining++;
		}
		if (gameObject.tag == "Medium Box"){
			Destroy (gameObject);
			particleSystem.startColor = Color.cyan;
			Instantiate (particleSystem, transform.position, Quaternion.identity);
			attempts.missesRemaining++;
		}
		if (gameObject.tag == "Small Box"){
			Destroy (gameObject);
			particleSystem.startColor = Color.blue;
			Instantiate (particleSystem, transform.position, Quaternion.identity);
			attempts.missesRemaining++;
		}
		if (gameObject.tag == "Very Small Box"){
			Destroy (gameObject);
			particleSystem.startColor = Color.yellow;
			Instantiate (particleSystem, transform.position, Quaternion.identity);
			attempts.missesRemaining++;
		}
		boxDisplay.boxCount--;
		AudioSource.PlayClipAtPoint (scoreClip, mainCamera.transform.position);
	}

}
