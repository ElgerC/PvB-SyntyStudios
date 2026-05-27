using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    [SerializeField] private PlayerHealthUIController playerHealthUIController;
    [SerializeField] private int healthIndex;
    private void Awake()
    {
        Initialize();
    }

    private void Initialize()
    {
        playerHealthUIController.GenerateHearts(healthIndex);
    }

    public void TakeDamage()
    {
        healthIndex--;
        playerHealthUIController.RemoveHeart(1);
    }
}
