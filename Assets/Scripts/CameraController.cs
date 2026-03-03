using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Cameras")]
    public Camera followCamera;
    public Camera rearCamera;

    [Header("Spaceship")]
    public Transform spaceship;

    [Header("Follow Settings")]
    public Vector3 offset = new Vector3(0f, 1f, -3f);
    public float smoothSpeed = 5f;

    [Header("Rear Settings")]
    public float rearFOV = 100f;
    public KeyCode rearCameraKey = KeyCode.R;

    // Sets camera positions based on spaceship location
    void Start()
    {
        rearCamera.fieldOfView = rearFOV;
        rearCamera.transform.SetParent(spaceship);
        rearCamera.transform.localPosition = new Vector3(0f, 0f, -2f);
        rearCamera.transform.localRotation = Quaternion.Euler(0f, 180f, 0f);

        followCamera.gameObject.SetActive(true);
        rearCamera.gameObject.SetActive(false);
    }

    void Update()
    {
        // Switch camera view if holding R
        if (Input.GetKeyDown(rearCameraKey))
        {
            followCamera.gameObject.SetActive(false);
            rearCamera.gameObject.SetActive(true);
        }
        if (Input.GetKeyUp(rearCameraKey))
        {
            followCamera.gameObject.SetActive(true);
            rearCamera.gameObject.SetActive(false);
        }
    }
    
    // Uncessessary but added smooth camera follow
    void LateUpdate()
    {
        if (followCamera.gameObject.activeSelf)
        {
            Vector3 desiredPos = spaceship.position + spaceship.TransformDirection(offset);
            followCamera.transform.position = Vector3.Lerp(followCamera.transform.position, desiredPos, smoothSpeed * Time.deltaTime);
            followCamera.transform.LookAt(spaceship.position);
        }
    }

}
