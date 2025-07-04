using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour {
	float horizontal;
	float vertical;
	Vector3 direction;
	public float speed = 8f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Move();
	}

	void Move() {
		horizontal = Input.GetAxis("Horizontal");
		vertical = Input.GetAxis("Vertical");
		direction = new Vector3(horizontal, 0, vertical) * speed * Time.deltaTime;

		gameObject.transform.position += direction;
	}

	void OnCollisionEnter(Collision otherCollision) {
		if(otherCollision.collider.gameObject.name == "Cube") {
			Debug.Log("Collision with Cube");
		}
	}
}
