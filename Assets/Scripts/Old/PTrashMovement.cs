using UnityEngine;

public class PTrashMovement : MonoBehaviour
{
    public Transform planet;
    float orbitSpeed = 30f;
    float rotationSpeed = 10f;
    

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, planet.position);
        float speed = orbitSpeed / Mathf.Sqrt(distance);

        transform.RotateAround(planet.position, Vector3.up, speed * Time.deltaTime);
        transform.Rotate(new Vector3(1, 1, 1) * rotationSpeed * Time.deltaTime);
        
    }
}
