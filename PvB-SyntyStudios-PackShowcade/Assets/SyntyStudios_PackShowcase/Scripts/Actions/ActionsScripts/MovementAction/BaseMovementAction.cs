using Cysharp.Threading.Tasks;
using packShowcase.actions;
using UnityEngine;

public class BaseMovementAction : BaseAction
{
    [Header("true is left, false is right")]
    [SerializeField] private bool direction;

    protected override UniTask ActionTask()
    {
        MoveTarget();
        return UniTask.CompletedTask;
    }

    protected void MoveTarget()
    {
        origin.MovementController.MoveInDirection(isMovingLeft: direction);
    }
}
