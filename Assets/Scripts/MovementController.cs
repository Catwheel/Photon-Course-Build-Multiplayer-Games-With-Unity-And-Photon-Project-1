using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField]
    float speed = 5f;
    private Vector3 velocity = Vector3.zero;
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
    }

    //Runs per physics iteration
    private void FixedUpdate()
    {
        if (velocity != Vector3.zero)
        {
            rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
        }
    }

    void Move(Vector3 movementVelocity)
    {
        velocity = movementVelocity;
    }
}
