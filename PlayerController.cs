using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    [Header("Values")]
    public float WalkingSpeed = 10;
    public float RunningSpeed = 15;
    public float CrouchingSpeed = 7;
    public float AirFactor = .5f;
    public float lookSpeed = 2;
    public float lookXLimit = 80;
    public float JumpVel = 7;
    public float CrouchingHeight = .8f;

    float height;
    
    [Space]
    [Header("References")]
    public Transform CameraContainer;

    CharacterController Controller;

    //Runtime
    bool isRunning;
    bool isCrouching;

    float rotationX = 0;
    Vector3 MoveVec;
    Vector3 Velocity;


    void Start() {
        Cursor.lockState = CursorLockMode.Locked;
        Controller = GetComponent<CharacterController>();
        height = Controller.height;
    }

    void Update() {
        isRunning = Input.GetKey(KeyCode.LeftShift);


        rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
        rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
        CameraContainer.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
        transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);


        float MoveX = (isCrouching ? CrouchingSpeed : (isRunning ? RunningSpeed : WalkingSpeed)) * Input.GetAxis("Horizontal");
        float MoveZ = (isCrouching ? CrouchingSpeed : (isRunning ? RunningSpeed : WalkingSpeed)) * Input.GetAxis("Vertical");

        MoveVec = transform.forward * MoveZ + transform.right * MoveX;


        if (!Controller.isGrounded) {
            Velocity = new Vector3(MoveVec.x * AirFactor, Velocity.y, MoveVec.z * AirFactor);
            Velocity.y -= PhysicsVariables.Gravity * Time.deltaTime;
        } else {
            Velocity = MoveVec;
            Velocity.y = -2f;
        }

        if (Controller.isGrounded && Input.GetButton("Jump")) {
            Velocity.y = JumpVel;
        }

        if (Input.GetKey(KeyCode.LeftControl)) {
            isCrouching = true;
            transform.localScale = new Vector3(1, CrouchingHeight, 1);
            Controller.height = CrouchingHeight * height;
        } else {
            isCrouching = false;
            transform.localScale = new Vector3(1, 1, 1);
            Controller.height = height;
        }


        Controller.Move(Velocity * Time.deltaTime);
    }
}
