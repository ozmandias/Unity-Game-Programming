using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	float horizontal;
	float vertical;
	Vector3 direction;
	Rigidbody playerBody;
	Camera playerCamera;
	[SerializeField] Animator playerAnimator;
	[SerializeField] ViewType currentViewType;
	[SerializeField] float speed = 8f;
	[SerializeField] float jumpForce = 10f;

	// Use this for initialization
	void Start () {
		playerBody = GetComponent<Rigidbody>();
		playerCamera = Camera.main;
		// playerAnimator = GetComponentInChildren<Animator>();
		currentViewType = ViewType.ThirdPerson;
		playerCamera.gameObject.GetComponent<GameCamera>().SetCameraViewType(currentViewType);
	}
	
	// Update is called once per frame
	void Update () {
		Move();
		ChangeViewMode();
	}

	void Move() {
		horizontal = Input.GetAxis("Horizontal");
		vertical = Input.GetAxis("Vertical");
		direction = new Vector3(horizontal, 0, vertical) * speed * Time.deltaTime;
		
		if(direction != Vector3.zero || currentViewType == ViewType.FirstPerson) {
			// transform.forward = direction;
			Rotate(direction);
			direction = currentViewType == ViewType.ThirdPerson ? transform.TransformDirection(Vector3.forward * speed * Time.deltaTime) : transform.TransformDirection(direction); // moves to facing direction.
			if(direction != Vector3.zero) {
				PlayAnimation("Run");
			} else {
				StopAnimation("Run");
			}
		} else {
			StopAnimation("Run");
		}

		if(Input.GetKeyDown(KeyCode.Space)) {
			// direction = new Vector3(direction.x, jumpForce, direction.z);
			playerBody.AddForce(Vector3.up * jumpForce);
		}
		
		gameObject.transform.position += direction;
	}

	void Rotate(Vector3 rotateDirection) {
		float rotateAngle = Vector3.SignedAngle(Vector3.forward, rotateDirection, Vector3.up);
		// Debug.Log("rotateAngle: " + rotateAngle);
		
		Vector3 cameraRotateDirection = new Vector3(0, playerCamera.gameObject.transform.rotation.eulerAngles.y, 0);
		
		// Quaternion rotation = Quaternion.Euler(0, rotateAngle + cameraRotateDirection.y + cameraRotateDirection.y, 0);
		Quaternion rotation = currentViewType == ViewType.ThirdPerson ? Quaternion.Euler(Vector3.up * rotateAngle + cameraRotateDirection) : Quaternion.Euler(Vector3.up + cameraRotateDirection);
		
		gameObject.transform.rotation = rotation;
	}

	void PlayAnimation(string animationName) {
		if(animationName == "Run") {
			playerAnimator.SetBool("Run", true);
		}
	}

	void StopAnimation(string animationName) {
		if(animationName == "Run") {
			playerAnimator.SetBool("Run", false);
		}
	}

	void ChangeViewMode() {
		if(Input.GetKeyDown(KeyCode.V)) {
			if(currentViewType == ViewType.ThirdPerson) {
				currentViewType = ViewType.FirstPerson;
			} else {
				currentViewType = ViewType.ThirdPerson;
			}
			playerCamera.gameObject.GetComponent<GameCamera>().SetCameraViewType(currentViewType);
		}
	}
}
