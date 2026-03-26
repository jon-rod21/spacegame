using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;


public class HUDController : MonoBehaviour
{
    [Header("Health")]
    public Slider healthBar;
    public float maxHealth = 100f;
    private float currentHealth;

    [Header("Ship Controls")]
    public Transform spaceship;
    public Button thrust;
    public float thrustBoost = 5f;

    public SpaceshipMovement spaceshipMovement;
    public float boostedSpeed;
    public float originalSpeed;
    

    [Header("Score")]
    public TextMeshProUGUI scoreText;
    private int score = 0;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.maxValue = maxHealth;
        healthBar.value = currentHealth;
        scoreText.text = $"Score: {score}";

        spaceshipMovement = spaceship.GetComponent<SpaceshipMovement>();
        originalSpeed = spaceshipMovement.moveSpeed;
        boostedSpeed = originalSpeed + thrustBoost;

        EventTrigger trigger = thrust.gameObject.AddComponent<EventTrigger>();

        EventTrigger.Entry pointerDown = new EventTrigger.Entry();
        pointerDown.eventID = EventTriggerType.PointerDown;
        pointerDown.callback.AddListener((_) => OnThrustDown());
        trigger.triggers.Add(pointerDown);

        EventTrigger.Entry pointerUp = new EventTrigger.Entry();
        pointerUp.eventID = EventTriggerType.PointerUp;
        pointerUp.callback.AddListener((_) => OnThrustUp());
        trigger.triggers.Add(pointerUp);

    }

    void OnThrustDown()
    {
        spaceshipMovement.moveSpeed = boostedSpeed;

    }

    void OnThrustUp()
    {
        spaceshipMovement.moveSpeed = originalSpeed;

    }


}
