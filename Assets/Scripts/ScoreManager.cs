using UnityEngine;
using TMPro; // ��� UI ������

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // UI-����� ��� ����������� �����
    private int score = 0;

    void Start()
    {
        UpdateScoreText();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Basketball")) // ���������, ��� ��� ���
        {
            score++; // ����������� ����
            UpdateScoreText();
        }
    }

    void UpdateScoreText()
    {
        if (scoreText != null)
            scoreText.text = "Score: " + score;
    }
}
