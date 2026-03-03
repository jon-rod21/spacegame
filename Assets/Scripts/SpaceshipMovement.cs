using UnityEngine;

public class SpaceshipMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float turnSpeed = 50f;

    void Update()
    {
        // Forward and Back movement
        float moveInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * moveInput * moveSpeed * Time.deltaTime);

        // Turning left and right
        float turnInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up * turnInput * turnSpeed * Time.deltaTime);

        // Up and Down
        float upDownInput = 0f;
        if (Input.GetKey(KeyCode.E)) upDownInput = 1f;
        if (Input.GetKey(KeyCode.Q)) upDownInput = -1f;
        transform.Translate(Vector3.up * upDownInput * moveSpeed * Time.deltaTime, Space.World);

    }
}
