using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class Box : MonoBehaviour {
	private Rigidbody boxRigidBody;
	private MeshRenderer meshRenderer;

	void Awake()
	{
		meshRenderer = GetComponent<MeshRenderer>();
		boxRigidBody = GetComponentInParent<Rigidbody>();
	}

	void Start () {
		SetColors();
		boxRigidBody.useGravity = false;
	}

	void SetColors () {
		if (gameObject.name == "X+") {
			meshRenderer.material.color = Color.red;
		}
		if (gameObject.name == "X-") {
			meshRenderer.material.color = Color.black;
		}
		if (gameObject.name == "Z+") {
			meshRenderer.material.color = Color.green;
		}
		if (gameObject.name == "Z-") {
			meshRenderer.material.color = Color.blue;
		}
	}
}

