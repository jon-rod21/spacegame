using UnityEngine;

public class FollowCameraFront : MonoBehaviour
{
    public Transform spacecraft;
    public Vector3 offset = new Vector3(0f, 3f, -6f);
    public float smoothSpeed = 5f;

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 desiredPos = spacecraft.position + spacecraft.TransformDirection(offset);
        transform.position = Vector3.Lerp(transform.position, desiredPos, smoothSpeed * Time.deltaTime);

        transform.LookAt(spacecraft.position);
        
    }
}
