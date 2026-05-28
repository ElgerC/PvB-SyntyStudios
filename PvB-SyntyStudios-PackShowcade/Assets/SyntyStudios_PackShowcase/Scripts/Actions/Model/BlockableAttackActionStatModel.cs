using UnityEngine;

[CreateAssetMenu(fileName = "BlockableAttackActionStatModel", menuName = "Scriptable Objects/ActionsStatModels/BlockableAttackActionStatModel")]

public class BlockableAttackActionStatModel : SimpleAttackActionStatModel
{
    [SerializeField] private float blockSelfDamage;
    public float BlockSelfDamage => blockSelfDamage;
}
