using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

public class BlackBoxesController : MonoBehaviour
{
    [SerializeField] private RectTransform canvas;
    [SerializeField] private RectTransform header;
    [SerializeField] private RectTransform footer;
    [SerializeField] private float openSize;
    [SerializeField] private float duration;

    private Sequence OpenSequence()
    {
        var runningNum = 0f;
        var closeSize = canvas.rect.height/2;
        var canvasWidth = canvas.rect.width;
        var Sequence = DOTween.Sequence().Append(DOVirtual.Float(closeSize,openSize,duration,(tweenNum) =>
        {
            var size = new Vector2(canvasWidth,tweenNum);
            
            header.sizeDelta = size;
            footer.sizeDelta = size;
        }));

        return Sequence;
    }

    private Sequence CloseSequence()
    {
        var runningNum = 0f;
        var closeSize = canvas.rect.height/2;
        var canvasWidth = canvas.rect.width;
        var Sequence = DOTween.Sequence().Append(DOVirtual.Float(openSize,closeSize,duration,(tweenNum) =>
        {
            var size = new Vector2(canvasWidth,tweenNum);
            
            header.sizeDelta = size;
            footer.sizeDelta = size;
        }));

        return Sequence;
    }

    public UniTask Open(bool instant = false)
    {
        if (instant)
        {
            var closeSize = canvas.rect.height/2;
            var canvasWidth = canvas.rect.width;
            var size = new Vector2(canvasWidth,openSize);
            
            header.sizeDelta = size;
            footer.sizeDelta = size;

            return UniTask.CompletedTask;
        }

        return OpenSequence().AsyncWaitForCompletion().AsUniTask();
    }

    public UniTask Close(bool instant = false)
    {
        if (instant)
        {
            var closeSize = canvas.rect.height/2;
            var canvasWidth = canvas.rect.width;
            var size = new Vector2(canvasWidth,closeSize);
            
            header.sizeDelta = size;
            footer.sizeDelta = size;

            return UniTask.CompletedTask;
        }
        
        return CloseSequence().AsyncWaitForCompletion().AsUniTask();
    }
}
