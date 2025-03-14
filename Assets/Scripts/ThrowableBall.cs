using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class ThrowableBall : XRGrabInteractable
{
    [SerializeField] private float throwForce = 10f; // —ила броска
    [SerializeField] private InputActionReference throwAction; // —сылка на действие Throw
    private bool isHeld = false; // ‘лаг, удерживаетс€ ли м€ч

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);
        isHeld = true; // ћ€ч вз€т в руку
    }

    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        base.OnSelectExited(args);
        isHeld = false; // ћ€ч отпущен
    }

    void Update()
    {
        if (isHeld && throwAction.action.triggered) // ѕровер€ем, нажата ли кнопка броска
        {
            ThrowBall();
        }
    }

    private void ThrowBall()
    {
        // ѕолучаем Rigidbody м€ча
        Rigidbody ballRigidbody = GetComponent<Rigidbody>();

        // ¬ычисл€ем направление броска (вперед от контроллера)
        Vector3 throwDirection = transform.forward;

        // ѕримен€ем силу к м€чу
        ballRigidbody.AddForce(throwDirection * throwForce, ForceMode.Impulse);

        // ќтпускаем м€ч
        isHeld = false;
        interactionManager.SelectExit(interactorsSelecting[0], this);
    }
}