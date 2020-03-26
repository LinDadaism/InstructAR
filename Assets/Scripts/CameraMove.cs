using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public float moveSpeed;

    CharacterController charControl; // controls camera movement

    void Awake()
    {
        charControl = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveCamera();
    }

    void MoveCamera()
    {
        float horizontal = Input.GetAxis("Horizontal_ArrowKeys");
        float vertical = Input.GetAxis("Vertical_ArrowKeys");

        Vector3 moveDirSide = transform.right * horizontal * (moveSpeed * 0.01f);
        Vector3 moveDirFwd = transform.forward * vertical * (moveSpeed * 0.01f);

        charControl.Move(moveDirSide);
        charControl.Move(moveDirFwd);
    }
}
