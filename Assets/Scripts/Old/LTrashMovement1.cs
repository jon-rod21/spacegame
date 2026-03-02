using UnityEngine;

public class LTrashMovement : MonoBehaviour
{
    public Transform moon;
    float orbitSpeed = 30f;
    //float rotationSpeed = 10f;

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, moon.position);
        float speed = orbitSpeed / Mathf.Sqrt(distance);

        Quaternion rotation = Quaternion.AngleAxis(speed * Time.deltaTime, new Vector3(1, 0, 1).normalized);
        transform.position = rotation * (transform.position - moon.position) + moon.position;
        transform.rotation = rotation * transform.rotation;

    }
}
