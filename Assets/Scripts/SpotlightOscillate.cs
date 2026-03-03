using UnityEngine;

public class SpotlightOscillate: MonoBehaviour
{
    public float angle = 30f;
    public float speed = 2f;

    void Update()
    {
        float y = Mathf.Sin(Time.time * speed) * angle;
        transform.localRotation = Quaternion.Euler(0f, y, 0f);
        
    }
}
