using UnityEngine;
using TMPro; // Для UI текста

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // UI-текст для отображения счета
    private int score = 0;

    void Start()
    {
        UpdateScoreText();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Basketball")) // Проверяем, что это мяч
        {
            score++; // Увеличиваем счет
            UpdateScoreText();
        }
    }

    void UpdateScoreText()
    {
        if (scoreText != null)
            scoreText.text = "Score: " + score;
    }
}
