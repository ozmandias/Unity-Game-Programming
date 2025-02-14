using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyParts : MonoBehaviour {

	Rigidbody bodyPartRigidBody;
	bool cut = false;

	// Use this for initialization
	void Start () {
		bodyPartRigidBody = GetComponent<Rigidbody>();
		bodyPartRigidBody.isKinematic = /*false*/ true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate() {
		// bodyPartRigidBody.velocity = Vector3.zero;
		if(cut == true && transform.childCount > 0) {
			// Debug.Log("Child still exists!");
			foreach(Transform child in transform) {
				// Debug.Log("Child: " + child.gameObject.name);
				child.gameObject.GetComponent<BodyParts>().CutBodyPart();
			}
		}
	}

	public void CutBodyPart() {
		// Debug.Log("CutBodyPart: " + gameObject.name);
		cut = true;
		bodyPartRigidBody.isKinematic = false;

		transform.SetParent(null);

		foreach(Transform child in transform) {
			child.gameObject.GetComponent<BodyParts>().CutBodyPart();
		}
	}

	void OnTriggerEnter(Collider otherCollider) {
		if(otherCollider.gameObject.CompareTag("Cutter")) {
			// Debug.Log("Cut by cutter");
			if(cut == false) {
				CutBodyPart();
			}
		}
	}

	void OnCollisionEnter(Collision otherCollision) {
		if(otherCollision.collider.gameObject.CompareTag("Ground")) {
			// Debug.Log("Hit ground");
			bodyPartRigidBody.isKinematic = true;
		}
	}
}
