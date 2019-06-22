using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour {

	private Rigidbody boxRigidBody;

	void Start () {
		setColors ();
		boxRigidBody = GetComponentInParent<Rigidbody> ();
		boxRigidBody.useGravity = false;
	}
	

	void setColors () {
		if (gameObject.name == "X+") {
			GetComponent<MeshRenderer>().material.color = Color.red;
		}
		if (gameObject.name == "X-") {
			GetComponent<MeshRenderer>().material.color = Color.black;
		}
		if (gameObject.name == "Z+") {
			GetComponent<MeshRenderer> ().material.color = Color.green;
		}
		if (gameObject.name == "Z-") {
			GetComponent<MeshRenderer> ().material.color = Color.blue;
		}
	}

	}

