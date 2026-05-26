using R3;
using UnityEngine;
using UnityEngine.InputSystem;

public static class UnityInputObservableExtension
{
    public static Observable<Unit> AsButtonObservable(this InputAction inputAction)
    {
        return Observable.FromEvent<InputAction.CallbackContext>(
                _ => inputAction.performed += _,
                _ => inputAction.performed -= _
        ).AsUnitObservable();
    }
}
