using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickView : MonoBehaviour
{
    public Joystick joystick;
    public Transform playerBody;
    public Camera m_Camera;
    float xRotation = 0.0f;
    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        float yRot = joystick.Vertical;
        float xRot = joystick.Horizontal;

        xRotation -= yRot;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);


        transform.localRotation = Quaternion.Euler(xRotation, 0.0f, 0.0f);
        playerBody.Rotate(Vector3.up * xRot);
       // m_Camera.transform.localEulerAngles += new Vector3(-yRot, xRot, 0);



    }
}
