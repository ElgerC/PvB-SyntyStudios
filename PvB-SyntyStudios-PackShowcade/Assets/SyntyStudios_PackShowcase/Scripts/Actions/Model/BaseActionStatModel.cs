using UnityEngine;

namespace packShowcase.actions.model
{
    [CreateAssetMenu(fileName = "BaseActionStatModel", menuName = "Scriptable Objects/ActionsStatModels/BaseActionStatModel")]
    public class BaseActionStatModel : ScriptableObject
    {
        [SerializeField] private float actionDuration;
        public float ActionDuration => actionDuration;
    }
}
