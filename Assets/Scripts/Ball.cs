using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Ball : MonoBehaviour {
	private Rigidbody ballRigidBody;
	private AttemptsRemaining misses;
	private BoxDisplay boxDisplay;
	private float yLaunchVelocity;

	Vector3 startPosition;
	Vector3 endPosition;
	float startTime;
	float endTime;
	Vector3 initialPosition;

	void Awake()
	{
		ballRigidBody = GetComponent<Rigidbody>();
	}

	void Start()
	{
		ballRigidBody.useGravity = false;
		initialPosition = transform.position;
		misses = FindFirstObjectByType<AttemptsRemaining>();
		boxDisplay = FindFirstObjectByType<BoxDisplay>();
		Reset();
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
		Vector3 flickPower = new(xSpeed, 0, zSpeed);
		float flickMagnitude = Vector3.Magnitude (flickPower);
		yLaunchVelocity = flickMagnitude / 5;
		initialVelocity = new Vector3(xSpeed, yLaunchVelocity, zSpeed);

		ballRigidBody.linearVelocity = initialVelocity;
		ballRigidBody.useGravity = true;
	}
	void OnCollisionEnter(Collision collider) {
		if (collider.gameObject.name == "Platform")
		{
			misses.missesRemaining--;
			misses.UpdateDisplay();
			if (boxDisplay.boxCount > 0)
			{
				Reset();
			}
		}
	}
	
	public void Reset()
	{
		ballRigidBody.useGravity = false;
		transform.position = initialPosition;
		ballRigidBody.linearVelocity = Vector3.zero;
		ballRigidBody.angularVelocity = Vector3.zero;
	}
}
