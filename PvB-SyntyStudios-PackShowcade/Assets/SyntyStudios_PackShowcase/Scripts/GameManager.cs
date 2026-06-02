using UnityEngine;
using Zenject;

public class GameManager : MonoBehaviour
{
    [Inject] private WaveController waveController;
    [Inject] private QuestController questController;
    private void Start()
    {
        StartWaves();
    }

    private void StartWaves()
    {
        waveController.SpawnWaveAndIncrementIndex();
        questController.SetQuestActiveById("Quest1");
    }
}
