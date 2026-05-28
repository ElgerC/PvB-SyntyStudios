using packShowcase.actions.model;
using UnityEngine;

[CreateAssetMenu(fileName = "ChannelAttackActionStatModel", menuName = "Scriptable Objects/ActionsStatModels/ChannelAttackActionStatModel")]
public class ChannelAttackActionStatModel : SimpleAttackActionStatModel
{
    [SerializeField] private float interruptSelfDamage;
    public float InterruptSelfDAmage => interruptSelfDamage;
}
