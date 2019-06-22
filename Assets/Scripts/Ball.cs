using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	public float yLaunchVelocity;

	private Rigidbody ballRigidBody;
	private AttemptsRemaining misses;
	private HitDetector hitDetector;
	private Camera mainCamera;

	Vector3 startPosition;
	Vector3 endPosition;
	float startTime;
	float endTime;
	Vector3 initialPosition;


	void Start () {
		ballRigidBody = GetComponent<Rigidbody> ();
		ballRigidBody.useGravity = false;
		initialPosition = transform.position;
		misses = FindObjectOfType<AttemptsRemaining> ();
		hitDetector = FindObjectOfType<HitDetector> ();
	}
	

	void OnMouseDown() {
		startTime = Time.time;
		startPosition = Input.mousePosition;
	}
	void OnMouseUp() {
		endTime = Time.time;
		endPosition = Input.mousePosition;
		Vector3 initialVelocity;
		float xSpeed = (endPosition.x - startPosition.x) / (endTime - startTime)/150;
		float zSpeed = (endPosition.y - startPosition.y) / (endTime - startTime)/100;
		ballRigidBody.angularVelocity = new Vector3 (10, 0, 10);
		initialVelocity = new Vector3 (xSpeed, yLaunchVelocity, zSpeed);
		Vector3 flickPower = new Vector3 (xSpeed, 0, zSpeed);
		float flickMagnitude = Vector3.Magnitude (flickPower);
		//Handle y velocity by flick power
		if (flickMagnitude < 10)
			yLaunchVelocity = 3;
		else if (flickMagnitude >= 10 && flickMagnitude < 15)
			yLaunchVelocity = 4;
		else if (flickMagnitude >= 15 && flickMagnitude < 20)
			yLaunchVelocity = 5;
		else if (flickMagnitude >= 20 && flickMagnitude < 25)
			yLaunchVelocity = 7;
		else if (flickMagnitude >= 25 && flickMagnitude < 30)
			yLaunchVelocity = 10;
		else if (flickMagnitude >= 30 && flickMagnitude < 35)
			yLaunchVelocity = 12;
		else if (flickMagnitude >= 35 && flickMagnitude < 40)
			yLaunchVelocity = 15;
		else if (flickMagnitude >= 40 && flickMagnitude < 50)
			yLaunchVelocity = 17;
		else if (flickMagnitude >= 50 && flickMagnitude < 60)
			yLaunchVelocity = 20;
		else if (flickMagnitude >= 60 && flickMagnitude < 70)
			yLaunchVelocity = 24;
		else
			yLaunchVelocity = 32;
		//end
		ballRigidBody.velocity = initialVelocity;
		ballRigidBody.useGravity = true;
	}
	void OnCollisionEnter(Collision collider) {
		if (collider.gameObject.name == "Platform") {
			Reset ();
			misses.missesRemaining--;
		}
	}
	public void Reset(){
		ballRigidBody.useGravity = false;
		transform.position = initialPosition;
		ballRigidBody.velocity = Vector3.zero;
		ballRigidBody.angularVelocity = Vector3.zero;
	}


}
