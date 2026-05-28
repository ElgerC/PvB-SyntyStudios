using packShowcase.actions.model;
using UnityEngine;

[CreateAssetMenu(fileName = "SimpleAttackActionStatModel", menuName = "Scriptable Objects/ActionsStatModels/SimpleAttackActionStatModel")]
public class SimpleAttackActionStatModel : BaseActionStatModel
{
    [SerializeField] private float delayUntilDamage;
    public float DelayUntilDamage => delayUntilDamage;
    [SerializeField] private float damage;
    public float Damage => damage;
    [SerializeField] private float attackDuration;
    public float AttackDuration => attackDuration;
    [SerializeField] private float retreatDuration;
    public float RetreatDuration => retreatDuration;
}
