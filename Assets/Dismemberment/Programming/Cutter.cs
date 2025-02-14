using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutter : MonoBehaviour {

	Camera cutterCamera;
	Rigidbody cutterBody;
	bool isCutting = false;
	GameObject currentTrail;
	Vector2 previousPosition;
	[SerializeField] float minimumCutVelocity = 0.001f;
	[SerializeField] GameObject cutterTrailPrefab;
	[SerializeField] Collider cutterCollider;

	// Use this for initialization
	void Start () {
		cutterCamera = Camera.main;
		cutterBody = GetComponent<Rigidbody>();
		cutterCollider.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		Cut();
	}

	void Cut() {
		if(Input.GetMouseButtonDown(0)) {
			isCutting = true;
			currentTrail = Instantiate(cutterTrailPrefab, transform);
			cutterCollider.enabled = false /*true*/;
		} else if (Input.GetMouseButtonUp(0)) {
			isCutting = false;
			currentTrail.transform.SetParent(null);
			Destroy(currentTrail);
			cutterCollider.enabled = false;
		}
		if(isCutting == true) {
			// Debug.Log("Cut");
			Vector2 cutterPosition = cutterCamera.ScreenToWorldPoint(Input.mousePosition);
			cutterBody.position = new Vector3(cutterPosition.x, cutterPosition.y, -0.5f) /*cutterPosition*/;

			float velocity = (cutterPosition - previousPosition).magnitude * Time.deltaTime;
			if(velocity > minimumCutVelocity) {
				cutterCollider.enabled = true;
			} else {
				cutterCollider.enabled = false;
			}

			previousPosition = cutterPosition;
		}
	}
}
