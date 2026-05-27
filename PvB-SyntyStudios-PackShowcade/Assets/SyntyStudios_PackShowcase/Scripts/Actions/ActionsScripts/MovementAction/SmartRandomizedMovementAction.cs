using Cysharp.Threading.Tasks;
using packShowcase.actions;
using UnityEngine;

public class SmartRandomizedMovementAction : BaseAction
{
    protected override async UniTask ActionTask()
    {
        MoveTarget();
        await UniTask.Delay((int)(statModel.ActionDuration*1000));
    }

    protected void MoveTarget()
    {
        bool random() => Random.Range(0, 2) == 0;
        var direction = random();
        var opposite = !direction;

        var originalDir = origin.MovementController.MoveInDirection(isMovingLeft: direction);

        if (!originalDir)
        {
            origin.MovementController.MoveInDirection(isMovingLeft: opposite);
        }
    }
}
