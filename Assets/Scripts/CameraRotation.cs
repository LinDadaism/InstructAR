using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public float speedH = 1; // horizontal rotational speed
    public float speedV = 1; // vertical rotational speed
    public float speedPos = 0.1f; // movement speed

    private Vector3 startPos = new Vector3(15,5,30); // start global position
    //private Vector3 startRot = new Vector3(30,180,0); // start global rotation

    private float inputX;

    void Start()
    {
        transform.position = startPos;
        //transform.eulerAngles = startRot;
        Debug.Log("camera ready");
    }

    void Update()
    {
        // update camera pos based on WASD key input
        if (Input.GetKey(KeyCode.W))
        {
            transform.position -= Vector3.forward * speedPos;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= Vector3.back * speedPos;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= Vector3.left * speedPos;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position -= Vector3.right * speedPos;
        }

        // update camera rot based on mouse input
        /*float yaw = speedH * Input.GetAxis("Mouse X");
        float pitch = speedV * Input.GetAxis("Mouse Y");

        transform.eulerAngles += new Vector3(pitch, yaw, 0);*/

        inputX = Input.GetAxis("Horizontal");
        if (inputX != 0)
        {
            transform.Rotate(new Vector3(0f, 5 * inputX * speedPos, 0f));
        }
    }
}
