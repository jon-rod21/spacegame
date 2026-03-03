using UnityEngine;

public class ProceduralOrbit : MonoBehaviour
{
    public Transform target;
    public Vector3 orbitAxis = Vector3.up;
    public float orbitSpeed = 60f;
    public bool useKeplerSpeed = true;

    private Vector3 lastTargetPos;

    void Start()
    {
        if (target != null)
            lastTargetPos = target.position;
    }


    void LateUpdate()
    {
        if (target == null) return;

        Vector3 targetDelta = target.position - lastTargetPos;
        transform.position += targetDelta;
        lastTargetPos = target.position;

        float dist = Vector3.Distance(transform.position, target.position);
        // If kepler speed is enabled, then objects will revolve slower farther, faster closer.
        float speed = useKeplerSpeed ? orbitSpeed / Mathf.Sqrt(dist) : orbitSpeed;

        Quaternion rotation = Quaternion.AngleAxis(speed * Time.deltaTime, orbitAxis);
        transform.position = rotation * (transform.position - target.position) + target.position;
    }
}
