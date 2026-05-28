using DG.Tweening;
using UnityEngine;

public class BlockableAttackAction : InterruptableAttackAction
{
    [SerializeField] private BlockableAttackActionStatModel blockableAttackStatModel;
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private float delayMaxRingSize;
    [SerializeField] private float delayMinRingSize;
    private bool blockable = false;

    protected override Sequence AttackAnimationSequence()
    {
        var target = targetContainer.transform.position;

        var sequence = DOTween.Sequence(this)
        .Append(attackOutlineSpriteRenderer.material.DOFade(1,blockableAttackStatModel.DelayUntilDamage))
        .Join(LineRendererAnimation(delayMaxRingSize,delayMinRingSize,blockableAttackStatModel.DelayUntilDamage))
        .AppendCallback(SetBlockable)
        .Append(origin.modelHolder.transform.DOMove(target,blockableAttackStatModel.AttackDuration))
        .Join(LineRendererAnimation(delayMinRingSize,0,blockableAttackStatModel.AttackDuration))
        .AppendCallback(SetUnBlockable)
        .AppendCallback(DealDamage)
        .Append(origin.modelHolder.transform.DOLocalMove(Vector3.zero,blockableAttackStatModel.RetreatDuration));

        return sequence;
    }

    private Tween LineRendererAnimation(float maxSize, float minSize, float duration)
    {
        var sequence = DOTween.Sequence(this).Append(DOVirtual.Float(maxSize,minSize,duration,(tweenNum)=>
        {
            LineRendererCircleExtension.MakeRing(lineRenderer,tweenNum,20);
        }));

        return sequence;
    }

    public override void Interrupt()
    {
        if (blockable)
        {
            attackSequence.Kill();
            origin.TargetInstabilityController.IncreaseInstability(blockableAttackStatModel.BlockSelfDamage);
            origin.modelHolder.transform.DOLocalMove(Vector3.zero,blockableAttackStatModel.RetreatDuration);
        }
    }

    private void SetBlockable()
    {
        blockable = true;
    }

        private void SetUnBlockable()
    {
        blockable = false;
    }
}
