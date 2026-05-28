using UnityEngine;
using UnityEngine.Events;

public class TargetInstabilityController : MonoBehaviour
{
    [SerializeField] private float reductionPerSecond;
    [SerializeField] private UnityEvent onInstability100;
    [SerializeField] private TargetInstabilityView view;
    private float instability = 0;

    void Awake()
    {
        view.Initialize(100);    
    }

    private void ReduceInstability()
    {
        var reduction = reductionPerSecond* Time.deltaTime;
        var newInstability = Mathf.Clamp( instability - reduction,0,100);
        
        instability = newInstability;
    }

    private void Update()
    {
        ReduceInstability();
        view.UpdateSlider(instability);
        view.UpdateTrackingPosition(transform.position);
        TryLaunchOn100Event();
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
}
