using UnityEngine;
using UnityEngine.UI;

public class TargetInstabilityView : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private Vector3 trackingOffSet;
    [SerializeField] private RectTransform rectTransform;

    public void Initialize(float maxValue)
    {
        slider.maxValue = maxValue;
        slider.minValue = 0;
    }

    public void UpdateSlider(float fillPercentage)
    {
        slider.value = fillPercentage;
    }

    public void UpdateTrackingPosition(Vector3 trackingTargetPosition)
    {
        var targetUiPosition = Camera.main.WorldToScreenPoint(trackingTargetPosition);
        var viewPosition = targetUiPosition + trackingOffSet;

        rectTransform.position = viewPosition;
    }
}
