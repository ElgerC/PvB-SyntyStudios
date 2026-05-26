using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using packShowcase.actions;
using UnityEngine;

public class BaseMovementAction : BaseAction
{
    [Header("true is left, false is right")]
    [SerializeField] private bool direction;

    protected override async UniTask ActionTask()
    {
        MoveTarget();
        await UniTask.Delay((int)(statModel.ActionDuration*1000));
    }

    protected void MoveTarget()
    {
        origin.MovementController.MoveInDirection(isMovingLeft: direction);
    }
}
