using UnityEngine;

public class SelfRotate : MonoBehaviour
{
    public Vector3 rotationAxis = Vector3.up;
    public float speed = 45f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotationAxis * speed * Time.deltaTime, Space.Self);
        
    }
}
