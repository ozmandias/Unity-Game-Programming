using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

public class RoomManager : MonoBehaviour {

	// public Vector3 playerLastPosition;

	public static RoomManager instance;

	void Awake () {
		if(instance == null) {
			instance = this;
		} else {
			Destroy(this.gameObject);
		}
		SceneManager.sceneLoaded += OnSceneLoaded;
	}
	
	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ChangeRoom(RoomData room) {
		switch(room.roomType) {
			case RoomType.World:
				SceneManager.LoadScene("RoomInterior_World");
				// GameObject.FindWithTag("Player").transform.position = /*GameObject.FindWithTag("DoorTrigger").transform.position*/ room.playerPosition;
				UIManager.instance.ClearSuggestionText();
				break;

			case RoomType.Home:
				// playerLastPosition = GameObject.FindWithTag("Player").transform.position;
				SceneManager.LoadScene("RoomInterior_Rooms");
				// GameObject.FindWithTag("Player").transform.position = /*GameObject.FindWithTag("DoorTrigger").transform.position*/ room.playerPosition;
				UIManager.instance.ClearSuggestionText();
				break;
			
			default:
				break;
		}
	}

	void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
		// Debug.Log("OnSceneLoaded");
		// Debug.Log("scene: " + scene.name + ", mode: " + mode);
		if(mode == LoadSceneMode.Single) {
			RepositionPlayer();
		}
	}

	void RepositionPlayer() {
		// Debug.Log("RepositionPlayer");
		GameObject player = GameObject.FindWithTag("Player");
		RoomData enteringRoomData = GameObject.FindWithTag("DoorTrigger").GetComponent<RoomData>();
		player.GetComponent<FirstPersonPlayer>().SetRotation(Quaternion.Euler(0,180f,0));
		player.transform.position = enteringRoomData.playerPositionTransform.position;
	}
}