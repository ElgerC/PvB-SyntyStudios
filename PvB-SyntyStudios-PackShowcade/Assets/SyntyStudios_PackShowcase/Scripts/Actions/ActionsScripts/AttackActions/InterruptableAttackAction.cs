using DG.Tweening;
using Cysharp.Threading.Tasks;

public class InterruptableAttackAction : SimpleAttackAction
{
    private Sequence attackSequence;
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

    public void Interrupt()
    {
        attackSequence.Kill();
    }
}