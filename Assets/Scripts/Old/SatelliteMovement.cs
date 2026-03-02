using UnityEngine;

public class SatelliteMovement : MonoBehaviour
{
    public Transform planet;
    float orbitSpeed = 100f;


    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, planet.position);
        float speed = orbitSpeed / Mathf.Sqrt(distance);

        Quaternion rotation = Quaternion.AngleAxis(speed * Time.deltaTime, new Vector3(0, 1, 1).normalized);
        transform.position = rotation * (transform.position - planet.position) + planet.position;
        transform.rotation = rotation * transform.rotation;
        
    }
}
