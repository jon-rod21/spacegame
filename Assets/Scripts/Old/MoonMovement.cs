using UnityEngine;

public class MoonMovement : MonoBehaviour
{
    public Transform planet;
    float orbitSpeed = 30f;
    float rotationSpeed = 10f;

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, planet.position);
        float speed = orbitSpeed / Mathf.Sqrt(distance);

        Debug.Log($"speed: {speed}");

        // orbit
        transform.RotateAround(planet.position, Vector3.up, speed * Time.deltaTime);

        // rotation
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        
    }
}
