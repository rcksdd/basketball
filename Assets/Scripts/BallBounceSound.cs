using UnityEngine;

public class BallBounceSound : MonoBehaviour
{
    public AudioSource bounceAudio; // Ссылка на AudioSource

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor")) // Проверяем, что мяч столкнулся с полом
        {
            bounceAudio.Play(); // Воспроизводим звук
        }
    }
}