using DG.Tweening;
using Cysharp.Threading.Tasks;

public class InterruptableAttackAction : SimpleAttackAction
{
    protected Sequence attackSequence;
    protected override async UniTask ActionTask()
    {
        Initialize();
        attackSequence = AttackAnimationSequence();

        var task = UniTask.WhenAny(
            attackSequence.AsyncWaitForCompletion().AsUniTask(),
            attackSequence.AsyncWaitForKill().AsUniTask()
        );

        await task;
    }

    public virtual void Interrupt()
    {
        attackSequence.Kill();
    }
}