using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class playerMovement : MonoBehaviour
{
    CharacterController characterController;
    Transform playerContainer, cameraContainer;

    public float speed = 6.0f;
    public float jumpSpeed = 10f;
    public float mouseSensitivity = 2f;
    public float gravity = 20.0f;
    public float lookUpClamp = -30f;
    public float lookDawnClamp = 60;

    private Vector3 moveDirection = Vector3.zero;
    float rotateX, rotateY;

    // Start is called before the first frame update
    void Start()
    {

        Cursor.visible = false;
        characterController = GetComponent<CharacterController>();
        SetCurrentCamera();

    }

    // Update is called once per frame
    void Update()
    {

        Locomotion();
        RotateAndLook();

        PerspectiveCheck();

    }

    void SetCurrentCamera()
    {

        playerContainer = gameObject.transform.Find("container3p");
        cameraContainer = playerContainer.transform.Find("camera3pcontainer");

    }

    void Locomotion()
    {

        if (characterController.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;


            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }

            if (Input.GetKey(KeyCode.C))
            {
                characterController.height = 0.65f;
                characterController.center = new Vector3(0f, 0.5f, 0f);
            }
            else if (Input.GetKey(KeyCode.C))
            {
                characterController.height = 2f;
                characterController.center = new Vector3(0f, 1f, 0f);
            }

        }

        moveDirection.y -= gravity * Time.deltaTime;
        characterController.Move(moveDirection * Time.deltaTime);

    }

    void RotateAndLook()
    {

        rotateX = Input.GetAxis("Mouse X") * mouseSensitivity;
        rotateY -= Input.GetAxis("Mouse Y") * mouseSensitivity;

        rotateY = Mathf.Clamp(rotateY, lookUpClamp, lookDawnClamp);
        transform.Rotate(0f, rotateX, 0f);

        cameraContainer.transform.localRotation = Quaternion.Euler(rotateY, 0f, 0f);

    }

    void PerspectiveCheck()
    {

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            switchPerspective switchPerspective = GetComponent<switchPerspective>();

            if (switchPerspective != null)
            {
                if (switchPerspective.GetPerspective() == switchPerspective.Perspective.First)
                {
                    switchPerspective.SetPerspective(switchPerspective.Perspective.Third);
                }
                else
                {
                    switchPerspective.SetPerspective(switchPerspective.Perspective.First);
                }

                SetCurrentCamera();
            }

        }

    }
}
