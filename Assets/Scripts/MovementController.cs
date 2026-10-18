using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.UIElements;

public class MovementController : MonoBehaviour
{
    [SerializeField]
    float speed = 5f;
    [SerializeField]
    float lookSensitivity = 3f;
    [SerializeField]
    GameObject fpsCamera;
    private Vector3 velocity = Vector3.zero;
    private Vector3 rotation = Vector3.zero;
    private float CameraUpAndDownRotation = 0f;
    private float CurrentCameraUpAndDownRotation = 0f;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Calculate Movement velocity as a 3D vector
        float _XMovement = Input.GetAxis("Horizontal");
        float _ZMovement = Input.GetAxis("Vertical");

        Vector3 _MovementHorizontal = transform.right * _XMovement;
        Vector3 _MovementVertical = transform.forward * _ZMovement;

        //Final movement velocity
        Vector3 _MovementVelocity = (_MovementHorizontal + _MovementVertical).normalized * speed;

        //Apply Movement
        Move(_MovementVelocity);

        //Calculate rotation as a 3D vector for turning around.
        float _YRotation = Input.GetAxis("Mouse X");
        Vector3 _RotationVector = new Vector3(0,_YRotation,0) * lookSensitivity;

        //Apply Rotation
        Rotate(_RotationVector);

        //Calculate look up and down camera rotation
        float _CameraUpDownRotation = Input.GetAxis("Mouse Y") * lookSensitivity;

        //Apply Rotation
        RotateCamera(_CameraUpDownRotation);
    }

    //Runs per physics iteration
    private void FixedUpdate()
    {
        if (velocity != Vector3.zero)
        {
            rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
        }

        rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation));

        if(fpsCamera != null)
        {
            CurrentCameraUpAndDownRotation -= CameraUpAndDownRotation;
            CurrentCameraUpAndDownRotation = Mathf.Clamp(CurrentCameraUpAndDownRotation, -85f, 85f);

            fpsCamera.transform.localEulerAngles = new Vector3(CurrentCameraUpAndDownRotation,0f,0f);
        }
    }

    void Move(Vector3 movementVelocity)
    {
        velocity = movementVelocity;
    }

    void Rotate(Vector3 rotationVector)
    {
        rotation = rotationVector;
    }

    void RotateCamera(float cameraUpDownRotation)
    {
        CameraUpAndDownRotation = cameraUpDownRotation;
    }
}
