using UnityEngine;

public class PlanetRotation : MonoBehaviour
{
    float rotationSpeed = 5.0f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        
    }
}
