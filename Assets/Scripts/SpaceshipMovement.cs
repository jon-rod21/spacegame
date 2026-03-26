using UnityEngine;

public class SpaceshipMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float turnSpeed = 50f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        rb.linearDamping = 0f;
        rb.angularDamping = 2f;
    }



    void Update()
    {
        // Forward and Back movement
        //float moveInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        //rb.MovePosition(rb.position + transform.forward * moveSpeed * Time.fixedDeltaTime);

        float pitch = turnSpeed * Time.deltaTime * Input.GetAxis("Vertical");
        float yaw = turnSpeed * Time.deltaTime * Input.GetAxis("Horizontal");

        float rollInput = 0f;
        if (Input.GetKey(KeyCode.E)) rollInput = 1f;
        if (Input.GetKey(KeyCode.Q)) rollInput = -1f;

        float roll = turnSpeed * Time.deltaTime * rollInput;
        transform.Rotate(pitch, yaw, roll);
        //rb.MoveRotation(rb.rotation * Quaternion.Euler(pitch, yaw, roll));


//        // Turning left and right
//        float turnInput = Input.GetAxis("Horizontal");
//        transform.Rotate(Vector3.up * turnInput * turnSpeed * Time.deltaTime);
//
//        // Up and Down
//        float upDownInput = 0f;
//        if (Input.GetKey(KeyCode.E)) upDownInput = 1f;
//        if (Input.GetKey(KeyCode.Q)) upDownInput = -1f;
//        transform.Translate(Vector3.up * upDownInput * moveSpeed * Time.deltaTime, Space.World);

    }
}
