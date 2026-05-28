using System;
using UnityEngine;
using UnityEngine.Events;
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
    private int waveIndex = 0;
    private int enemyIndex = 0;

    public void SpawnWaveAndIncrementIndex()
    {
        if(waveIndex >= enemyWaves.Length)
        {
            OnFinalWaveReached.Invoke();
            Debug.Log("final wave reached");
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
