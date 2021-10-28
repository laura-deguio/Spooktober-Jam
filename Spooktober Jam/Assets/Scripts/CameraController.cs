using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Vector2 turn;

    public float sensitivity = .5f;

    public Vector3 deltaMove;

    public float speed = 1;

    public GameObject mover;

    void Start()

    {

        Cursor.lockState = CursorLockMode.Locked;

    }

    void Update()

    {

        turn.x += Input.GetAxis("Mouse X") * sensitivity;

        turn.y += Input.GetAxis("Mouse Y") * sensitivity;

        transform.localRotation = Quaternion.Euler(-turn.y, turn.x, 0);

        deltaMove = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")) * speed;
        mover.transform.Translate(deltaMove);
    }
}
