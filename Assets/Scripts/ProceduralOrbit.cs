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


    // Update is called once per frame
    void Update()
    {
        if (target == null) return;

        Vector3 targetDelta = target.position - lastTargetPos;
        transform.position += targetDelta;
        lastTargetPos = target.position;

        float dist = Vector3.Distance(transform.position, target.position);
        float speed = useKeplerSpeed ? orbitSpeed / Mathf.Sqrt(dist) : orbitSpeed;

        Quaternion rotation = Quaternion.AngleAxis(speed * Time.deltaTime, orbitAxis);
        transform.position = rotation * (transform.position - target.position) + target.position;
        
    }
}
