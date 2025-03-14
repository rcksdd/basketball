using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class ThrowableBall : XRGrabInteractable
{
    [SerializeField] private float throwForce = 10f; // ���� ������
    [SerializeField] private InputActionReference throwAction; // ������ �� �������� Throw
    private bool isHeld = false; // ����, ������������ �� ���

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);
        isHeld = true; // ��� ���� � ����
    }

    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        base.OnSelectExited(args);
        isHeld = false; // ��� �������
    }

    void Update()
    {
        if (isHeld && throwAction.action.triggered) // ���������, ������ �� ������ ������
        {
            ThrowBall();
        }
    }

    private void ThrowBall()
    {
        // �������� Rigidbody ����
        Rigidbody ballRigidbody = GetComponent<Rigidbody>();

        // ��������� ����������� ������ (������ �� �����������)
        Vector3 throwDirection = transform.forward;

        // ��������� ���� � ����
        ballRigidbody.AddForce(throwDirection * throwForce, ForceMode.Impulse);

        // ��������� ���
        isHeld = false;
        interactionManager.SelectExit(interactorsSelecting[0], this);
    }
}