using UnityEngine;

public class BasketTrigger : MonoBehaviour
{
    public ScoreManager scoreManager;
    public AudioSource basketAudio; // Ссылка на AudioSource

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Basketball"))
        {
            basketAudio.Play(); // Воспроизводим звук
        }
    }
}