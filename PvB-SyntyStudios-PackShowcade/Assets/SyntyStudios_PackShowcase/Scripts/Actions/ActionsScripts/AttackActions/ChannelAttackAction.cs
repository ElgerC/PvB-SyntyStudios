using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class ChannelAttackAction : InterruptableAttackAction
{
    [SerializeField] private GameObject channelBarTemplate;
    [SerializeField] private ChannelAttackActionStatModel channelAttackStatModel;
    [SerializeField] private Vector3 offSet;
    private Slider channelSlider;
    private RectTransform sliderTransform;

    protected override UniTask ActionTask()
    {
        CreateChannelBar();
        return base.ActionTask();
    }

    protected override Sequence AttackAnimationSequence()
    {
        var target = targetContainer.transform.position;

        var sequence = DOTween.Sequence(this).Append(DOVirtual.Float(0,1,channelAttackStatModel.AttackDuration,(tweenNum)=>
        {
            if(channelSlider != null)
            {
                channelSlider.value = tweenNum;
            }
        })).AppendCallback(EndAttack);

        return sequence;
    }

    private void Update()
    {
        UpdateSliderPosition();
    }

    public override void Interrupt()
    {
        attackSequence.Kill();
        Destroy(channelSlider.gameObject);
        origin.TargetInstabilityController.IncreaseInstability(channelAttackStatModel.InterruptSelfDAmage);
        
    }

    private void CreateChannelBar()
    {
        var parentObject = GameObject.FindWithTag("ChannelSlider");
        var newBar = Instantiate(channelBarTemplate,parentObject.transform);
        channelSlider = newBar.GetComponent<Slider>();
        sliderTransform = newBar.GetComponent<RectTransform>();
    }

    public override void Stop()
    {
        if(channelSlider != null)
        {
            Destroy(channelSlider.gameObject); 
        }
        base.Stop();
    }

    private void EndAttack()
    {
        FindAnyObjectByType<PlayerActionController>().TargetInstabilityController.IncreaseInstability(channelAttackStatModel.Damage);

        Destroy(channelSlider.gameObject);
    }

    public void UpdateSliderPosition()
    {
        var targetUiPosition = Camera.main.WorldToScreenPoint(origin.transform.position);
        var viewPosition = targetUiPosition + offSet;   

        if(sliderTransform != null)
        {
            sliderTransform.position = viewPosition;
        }
    }
}
