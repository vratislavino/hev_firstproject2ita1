using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    Vector3 rotation;
    Vector3 cameraRotation;

    Rigidbody rb;
    public Rigidbody Rb => rb;
    [SerializeField] private float speed;
    private float speedEnvMult = 1;
    [SerializeField] private float jumpForce;
    [SerializeField] private float mouseSensitivity;

    [SerializeField] private Transform cameraHolder;

    [SerializeField] private Transform grouncCheck;

    bool isGrounded = false;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        rb = GetComponent<Rigidbody>();   
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.Raycast(grouncCheck.position, Vector3.down, 0.04f);

        float xMove = Input.GetAxis("Horizontal");
        float zMove = Input.GetAxis("Vertical");
        float yMove = rb.velocity.y;
        float currentSpeed = speed;

        Vector3 direction = new Vector3(xMove, 0f, zMove);
        direction = Quaternion.Euler(0, transform.eulerAngles.y, 0) * direction;

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            yMove = jumpForce;
        }

        if (Input.GetButton("Sprint"))
            currentSpeed *= 1.5f;

        currentSpeed *= speedEnvMult;

        rb.velocity = new Vector3(direction.x * currentSpeed, yMove, direction.z * currentSpeed);


        float xRot = Input.GetAxis("Mouse Y");
        float yRot = Input.GetAxis("Mouse X");

        cameraRotation.x -= xRot * mouseSensitivity;
        rotation.y += yRot * mouseSensitivity;

        // omezení rotace po ose X
        cameraRotation.x = Mathf.Clamp(cameraRotation.x, -80, 50);


        transform.rotation = Quaternion.Euler(rotation);
        cameraHolder.localRotation = Quaternion.Euler(cameraRotation);
    }

    public void ChangeEnvironmentSpeedMultiplier(float newMult)
    {
        speedEnvMult = newMult;
    }
}
