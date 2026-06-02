using System.Linq;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using packShowcase.actions.controller;
using UnityEngine;
using Zenject;

public class EnemyActionController : BaseActionController
{
    [System.Serializable]
    private class ActionChanceMatch
    {
        public GameObject actionObject;
        public float baseChance;
        public float maxNum;
    }

    [SerializeField] private ActionChanceMatch[] actionChanceMatches;
    [SerializeField] private float enemyActionCooldown;
    [SerializeField] private QuestModel quest;
    [Inject] private WaveController waveController;
    [Inject] private QuestController questController;
    private bool coolingDown = false;

    public override void Initialize()
    {
        base.Initialize();
        CalculateMaxNumbers();
    }

    private void CalculateMaxNumbers()
    {
        var completeChance = actionChanceMatches.Sum(_ => _.baseChance);
        Debug.Log(completeChance);
        var conversionRate = 100 / completeChance;
        var rollingMaxNum = 0f;

        for (int i = 0; i < actionChanceMatches.Length; i++)
        {
            var match = actionChanceMatches[i];
            var chance = match.baseChance * conversionRate;
            var newMaxNum = chance+rollingMaxNum;

            match.maxNum = newMaxNum;
            rollingMaxNum += chance;
        }
    }

    private ActionChanceMatch GetRandomAction()
    {
        var randomizedNumber = Random.Range(0,100);
        var action = actionChanceMatches.FirstOrDefault(_ => _.maxNum > randomizedNumber);

        return action;
    }

    private async UniTask TryPlayAction()
    {
        if(currentAction == null && coolingDown == false)
        {
            coolingDown = true;
            var action = GetRandomAction();
            await PlayAction(action.actionObject);
            await UniTask.Delay((int)(enemyActionCooldown*1000));
            coolingDown = false;
        }
    }

    private void Update()
    {
        TryPlayAction().Forget();
    }

    public void KillEnemy()
    {
        waveController.SpawnWaveAndIncrementIndex();
        currentAction?.Stop();
        TryFinishQuest();
        Destroy(gameObject);
    }

    private void TryFinishQuest()
    {
        if(quest == null)
        {
            return;
        }

        questController.SetNextQuestActive(quest.id);
    }
}
