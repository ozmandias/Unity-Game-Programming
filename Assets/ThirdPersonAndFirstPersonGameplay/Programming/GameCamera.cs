using UnityEngine;

public class GameCamera : MonoBehaviour {
    float mouseHorizontal = 0;
    float mouseVertical = 0;
    [SerializeField] float cameraSpeed = 4f;
    [SerializeField] float cameraDistance = -1f;
    [SerializeField] float cameraHeight = 1f;
    [SerializeField] GameObject playerCameraLookObject;
    [SerializeField] ViewType cameraViewType;

    void Start() {

    }

    void Update() {
        // CameraMove();
    }

    void LateUpdate() {
        CameraMove();
    }

    void CameraMove() {
        mouseHorizontal += Input.GetAxis("Mouse X") * cameraSpeed;
        mouseVertical -= Input.GetAxis("Mouse Y") * cameraSpeed;
        CameraRotate();
        Vector3 followPosition = cameraViewType == ViewType.ThirdPerson ? new Vector3(playerCameraLookObject.transform.position.x, playerCameraLookObject.transform.position.y, playerCameraLookObject.transform.position.z) + (cameraDistance * transform.forward) : new Vector3(playerCameraLookObject.transform.position.x, playerCameraLookObject.transform.position.y, playerCameraLookObject.transform.position.z);
        gameObject.transform.position = followPosition;
    }

    void CameraRotate() {
        gameObject.transform.rotation = Quaternion.Euler(mouseVertical,mouseHorizontal,0);
    }

    public void SetCameraViewType(ViewType _viewType) {
        cameraViewType = _viewType;
        playerCameraLookObject = cameraViewType == ViewType.ThirdPerson ? GameObject.Find("ThirdPersonCameraLook") : GameObject.Find("FirstPersonCameraLook");
    }
}