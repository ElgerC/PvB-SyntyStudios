using Cysharp.Threading.Tasks;
using DG.Tweening;
using packShowcase.actions;
using packShowcase.side;
using packShowcase.targetContainer;
using UnityEngine;
using Zenject;

public class SimpleAttackAction : BaseAction
{
    [SerializeField] private SimpleAttackActionStatModel attackStatModel;
    [SerializeField] protected MeshRenderer attackOutlineSpriteRenderer;
    [Inject] private TargetContainerController targetContainerController;
    protected TargetContainer targetContainer;
    private Vector3 startPosition;
    protected override UniTask ActionTask()
    {
        Initialize();
        return AttackAnimationSequence().AsyncWaitForCompletion().AsUniTask();
    }

    protected virtual Sequence AttackAnimationSequence()
    {
        var target = targetContainer.transform.position;

        var sequence = DOTween.Sequence(this)
        .Append(attackOutlineSpriteRenderer.material.DOFade(1,attackStatModel.DelayUntilDamage))
        .Append(origin.modelHolder.transform.DOMove(target,attackStatModel.AttackDuration))
        .AppendCallback(DealDamage)
        .Append(origin.modelHolder.transform.DOLocalMove(Vector3.zero,attackStatModel.RetreatDuration));

        return sequence;
    }

    protected void DealDamage()
    {
        targetContainer.target?.TargetInstabilityController.IncreaseInstability(attackStatModel.Damage);
        targetContainer.target?.TryInterruptAction();
    }

    protected void Initialize()
    {
        startPosition = origin.transform.position;

        var targetContainerIndex = origin.MovementController.containerIndex;
        targetContainer = targetContainerController.GetTargetContainers(OppositeSide())[targetContainerIndex];
    }

    protected Side OppositeSide()
    {
        if(origin.Side == Side.player)
        {
            return Side.enemy;
        }
        else
        {
            return Side.player;
        }
    }
}
