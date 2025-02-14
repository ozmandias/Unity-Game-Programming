using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityStandardAssets.CrossPlatformInput;

[Serializable]
public class FirstPersonMouseLook : MouseLook {
    public float xRot = 0;
    public float yRot = 0;
    public bool settingRotation = false;


    public override void LookRotation(Transform character, Transform camera)
    {
        // Debug.Log("FirstPersonMouseLook-LookRotation");
        yRot = Input.GetAxis("Mouse X") * XSensitivity;
        xRot = Input.GetAxis("Mouse Y") * YSensitivity;
        // Debug.Log("xRot: " + xRot + ", yRot: " + yRot);

        if(settingRotation == false) {
            m_CharacterTargetRot *= Quaternion.Euler (0f, yRot, 0f);
            m_CameraTargetRot *= Quaternion.Euler (-xRot, 0f, 0f);
        }

        if(clampVerticalRotation)
            // Debug.Log("BeforeClamp: " + m_CameraTargetRot);
            m_CameraTargetRot = ClampRotationAroundXAxis (m_CameraTargetRot);
            // Debug.Log("AfterClamp: " + m_CameraTargetRot);

        if(smooth)
        {
            // Debug.Log("smooth");
            character.localRotation = Quaternion.Slerp (character.localRotation, m_CharacterTargetRot,
                smoothTime * Time.deltaTime);
            camera.localRotation = Quaternion.Slerp (camera.localRotation, m_CameraTargetRot,
                smoothTime * Time.deltaTime);
        }
        else
        {
            character.localRotation = m_CharacterTargetRot;
            camera.localRotation = m_CameraTargetRot;
            // Debug.Log("not smooth -> m_CharacterTargetRot: " + m_CharacterTargetRot + ", m_CameraTargetRot: " + m_CameraTargetRot);
        }

        UpdateCursorLock();
    }
}