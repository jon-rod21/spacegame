using UnityEngine;

public class SelfRotate : MonoBehaviour
{
    public Vector3 rotationAxis = Vector3.up;
    public float speed = 45f;

    void LateUpdate()
    {
        transform.Rotate(rotationAxis * speed * Time.deltaTime);
        
    }
}
