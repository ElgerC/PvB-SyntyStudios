using UnityEngine;
using Zenject;

public class GameManager : MonoBehaviour
{
    [Inject] private WaveController waveController;
    private void Start()
    {
        StartWaves();
    }

    private void StartWaves()
    {
        waveController.SpawnWaveAndIncrementIndex();
    }
}
