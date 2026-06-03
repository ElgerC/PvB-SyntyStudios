using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using Zenject;

public class WaveController : MonoBehaviour
{
    [System.Serializable]
    private class EnemyWave
    {
        public GameObject[] enemyTemplates;
        private int enemyIndex = 0;
    }

    public UnityEvent OnFinalWaveReached;
    [SerializeField] private EnemyWave[] enemyWaves;
    [Inject] private EnemyFactory enemyFactory;
    [Inject] private GameManager gameManager;
    private int waveIndex = 0;
    private int enemyIndex = 0;

    public void SpawnWaveAndIncrementIndex()
    {
        if(waveIndex >= enemyWaves.Length)
        {
            OnFinalWaveReached.Invoke();
            Debug.Log("final wave reached");
            gameManager.CloseGame().Forget();
            return;
        } 

        var enemy = enemyWaves[waveIndex].enemyTemplates[enemyIndex];
        enemyFactory.SpawnEnemy(enemy);

        enemyIndex++;

        if(enemyIndex >= enemyWaves[waveIndex].enemyTemplates.Length)
        {
            waveIndex++;
            enemyIndex = 0;
        }
    }
}
