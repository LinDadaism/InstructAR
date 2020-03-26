using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    public float rotSensitivity;

    float xAxisClamp = 0.0f;

    void Update()
    {
        RotateCamera();
    }

    void RotateCamera()
    {
        float rotX = Input.GetAxis("Horizontal_WASD");
        float rotY = Input.GetAxis("Vertical_WASD");

        float rotAmountX = rotX * rotSensitivity * 0.01f;
        float rotAmountY = rotY * rotSensitivity * 0.01f;

        xAxisClamp -= rotAmountY;

        Vector3 targetRotCam = transform.rotation.eulerAngles;

        targetRotCam.x -= rotAmountY;
        targetRotCam.z = 0;
        targetRotCam.y += rotAmountX;

        if (xAxisClamp > 90)
        {
            xAxisClamp = 90;
            targetRotCam.x = 90;
        }
        else if (xAxisClamp < -90)
        {
            xAxisClamp = -90;
            targetRotCam.x = 270;
        }

        transform.rotation = Quaternion.Euler(targetRotCam);
    }
}
