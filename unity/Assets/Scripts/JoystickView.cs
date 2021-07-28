using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickView : MonoBehaviour
{
    public Joystick joystick;
    private Quaternion m_CharacterTargetRot;
    private Quaternion m_CameraTargetRot;
    public Camera m_Camera;

    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        float yRot = joystick.Vertical;
        float xRot = joystick.Horizontal;

        m_Camera.transform.localEulerAngles += new Vector3(-yRot, xRot, 0);



    }
}
