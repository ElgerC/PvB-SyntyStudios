using UnityEngine;
using UnityEngine.Events;

public class TargetInstabilityController : MonoBehaviour
{
    [SerializeField] private float reductionPerSecond;
    [SerializeField] private UnityEvent onInstability100;
    [SerializeField] private TargetInstabilityView view;
    private float instability = 0;
    private bool initialized = false;

    public void Initialize()
    {
        view.Initialize(100);    
        initialized = true;
    }

    private void ReduceInstability()
    {
        var reduction = reductionPerSecond* Time.deltaTime;
        var newInstability = Mathf.Clamp( instability - reduction,0,100);
        
        instability = newInstability;
    }

    private void Update()
    {
        if(initialized)
        {
            ReduceInstability();
            view.UpdateSlider(instability);
            view.UpdateTrackingPosition(transform.position);
            TryLaunchOn100Event();
        }
    }

    private void TryLaunchOn100Event()
    {
        if(instability < 100)
        {
            return;
        }

        onInstability100.Invoke();
        instability = 0;
    }

    public void IncreaseInstability(float amount)
    {
        var newInstability = Mathf.Clamp( instability + amount,0,100);
        instability = newInstability;
    }

    public void SetInstabilityView(TargetInstabilityView targetView)
    {
        view = targetView;
    }
}
