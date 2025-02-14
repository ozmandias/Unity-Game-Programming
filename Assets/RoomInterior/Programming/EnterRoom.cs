using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterRoom : MonoBehaviour {
	bool nearDoor = false;
	RoomData newRoom;
	public static EnterRoom instance;

	void Awake() {
		if(instance == null) {
			instance = this;
		} else {
			Destroy(this.gameObject);
		}
	}

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		EnterDoor();
	}

	void EnterDoor() {
		if(nearDoor == true && Input.GetKey(KeyCode.E)) {
			RoomManager.instance.ChangeRoom(newRoom);
		}
	}

	void OnTriggerEnter(Collider otherCollider) {
		if(otherCollider.gameObject.CompareTag("DoorTrigger")) {
			nearDoor = true;
			string suggestionMessage = "";
			newRoom = otherCollider.gameObject.GetComponent<RoomData>();
			suggestionMessage = "Press 'E' to enter " + newRoom.roomType.ToString() + ".";
			UIManager.instance.SetSuggestionText(suggestionMessage);
			// Debug.Log(suggestionMessage);
		}
	}

	void OnTriggerExit(Collider otherCollider) {
		if(otherCollider.gameObject.CompareTag("DoorTrigger")) {
			nearDoor = false;
			newRoom = null;
			UIManager.instance.ClearSuggestionText();
		}
	}
}
