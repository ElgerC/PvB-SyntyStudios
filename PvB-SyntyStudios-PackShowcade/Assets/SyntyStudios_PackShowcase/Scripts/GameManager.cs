using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class GameManager : MonoBehaviour
{
    [Inject] private WaveController waveController;
    [Inject] private QuestController questController;
    [SerializeField] private BlackBoxesController blackBoxesController;

    void Awake()
    {
        blackBoxesController.Close(true);
    }
    private void Start()
    {
        blackBoxesController.Open().Forget();
        StartWaves();
    }

    private void StartWaves()
    {
        waveController.SpawnWaveAndIncrementIndex();
        questController.SetQuestActiveById("Quest1");
    }

    public async UniTask CloseGame()
    {
        await blackBoxesController.Close();
        SceneManager.LoadScene("EndScreen");
    }
}
