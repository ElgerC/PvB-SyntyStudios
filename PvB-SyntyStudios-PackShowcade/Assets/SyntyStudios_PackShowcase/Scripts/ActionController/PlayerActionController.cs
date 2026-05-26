using Cysharp.Threading.Tasks;
using packShowcase.actions.controller;
using R3;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerActionController : BaseActionController
{
    [System.Serializable]
    private class ActionInputMatch
    {
        public GameObject actionObject;
        public InputActionReference inputAction;
    }

    private void SubscribeActionToInput(GameObject action, InputAction input)
    {
        var observable = input.AsButtonObservable();
        observable.Subscribe(_ => {PlayAction(action).Forget();});
    }

    [SerializeField] private ActionInputMatch[] actionInputMatches;
    protected override void Initialize()
    {
        foreach(var match in actionInputMatches)
        {
            SubscribeActionToInput(match.actionObject,match.inputAction);
        }
        base.Initialize();
    }
}
