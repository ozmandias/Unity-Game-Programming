using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityStandardAssets.CrossPlatformInput;

public class FirstPersonPlayer : FirstPersonController {
    public FirstPersonMouseLook playerFirstPersonMouseLook;
    Quaternion newRotation;

    public override void Start() {
        base.Start();
        InitFirstPersonMouseLook();
    }
    
    public override void Update() {
        base.Update();
        if(playerFirstPersonMouseLook.settingRotation == true) {
            transform.localRotation = newRotation;
            // Input.ResetInputAxes();
            // StartCoroutine(ResetRotation());
            playerFirstPersonMouseLook.settingRotation = false;
            InitFirstPersonMouseLook();
        }
    }

    public override void FixedUpdate() {
        base.FixedUpdate();
    }

    public override void RotateView() {
        // base.RotateView();
        playerFirstPersonMouseLook.LookRotation (transform, m_Camera.transform);
    }

    public override void GetInput(out float speed) {
        base.GetInput(out speed);
    }

    public void SetRotation(Quaternion _newRotation) {
        Debug.Log("SetRotation");
        playerFirstPersonMouseLook.settingRotation = true;
        newRotation = _newRotation;
    }

    IEnumerator ResetRotation() {
        yield return new WaitForSeconds(0.1f);
        playerFirstPersonMouseLook.settingRotation = false;
    }

    public void InitFirstPersonMouseLook() {
        playerFirstPersonMouseLook.Init(transform , m_Camera.transform);
    }
}