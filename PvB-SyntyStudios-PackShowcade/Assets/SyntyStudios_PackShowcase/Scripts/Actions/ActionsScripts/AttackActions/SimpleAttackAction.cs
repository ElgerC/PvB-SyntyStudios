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
    private bool triedInteruption = false;
    private Sequence attackSequence;
    protected override UniTask ActionTask()
    {
        Initialize();
        attackSequence = AttackAnimationSequence();
        return attackSequence.AsyncWaitForCompletion().AsUniTask();
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
        
    }

    private void Update()
    {
        if(!targetContainer.target)
        {
            return;
        }

        var originPos = origin.modelHolder.transform.position;
        var targetPos = targetContainer.target.modelHolder.transform.position;
            
        
        var dist = Vector3.Distance(originPos,targetPos);

        if(dist < 1 && !triedInteruption)
        {
            if (targetContainer.target.TryInterruptAction())
            {
                attackSequence.Kill();
                triedInteruption = true;
                BlockAttack();
            }
        }
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

    private void BlockAttack()
    {
        origin.modelHolder.transform.DOMove(startPosition,0.1f);
    }
}
