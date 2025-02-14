using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Force : MonoBehaviour {

	Rigidbody objectBody;
	[SerializeField]float moveForce = 4f;

	// Use this for initialization
	void Start () {
		objectBody = gameObject.GetComponent<Rigidbody>();	
	}
	
	// Update is called once per frame
	void Update () {
		// PushForce();
	}

	void FixedUpdate () {
		PushForce();
	}
	
	void PushForce() {
		Vector3 forceDirection = transform.forward + transform.up;
		objectBody.AddForce(forceDirection * moveForce);
		// if(gameObject.transform.position.y < 2f) {
		// 	objectBody.velocity = forceDirection * moveForce;
		// }else{
		// 	objectBody.velocity = Vector3.zero;
		// }
	}
}
