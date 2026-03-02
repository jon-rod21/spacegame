using UnityEngine;

public class SpotlightOscillate: MonoBehaviour
{
    public float angle = 30f;
    public float speed = 2f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float y = Mathf.Sin(Time.time * speed) * angle;
        transform.localRotation = Quaternion.Euler(0f, y, 0f);
        
    }
}
