using UnityEngine;

public class BallBounceSound : MonoBehaviour
{
    public AudioSource bounceAudio; // ������ �� AudioSource

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor")) // ���������, ��� ��� ���������� � �����
        {
            bounceAudio.Play(); // ������������� ����
        }
    }
}