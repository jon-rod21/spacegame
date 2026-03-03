using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUDController : MonoBehaviour
{
    [Header("Health")]
    public Slider healthBar;
    public float maxHealth = 100f;
    private float currentHealth;

    [Header("Score")]
    public TextMeshProUGUI scoreText;
    private int score = 0;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.maxValue = maxHealth;
        healthBar.value = currentHealth;
        scoreText.text = $"Score: {score}";
    }
}
