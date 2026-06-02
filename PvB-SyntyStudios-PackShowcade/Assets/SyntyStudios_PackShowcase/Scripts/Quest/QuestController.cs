using UnityEngine;
using TMPro;
using System.Linq;

public class QuestController : MonoBehaviour
{
    [SerializeField] private TMP_Text questText;
    [SerializeField] private GameObject questBox;

    [System.Serializable]
    private class Quest
    {
        public bool isCompleted = false;
        public QuestModel questModel;
    }

    [SerializeField] private Quest[] quests;
    private Quest activeQuest;
    private int questIndex = 0;

    public void SetNextQuestActive(string currentQuestID)
    {
        var newIndex = questIndex + 1;
        if(newIndex >= quests.Length || currentQuestID != activeQuest.questModel.id)
        {
            questBox.SetActive(false);
            return;
        }
        activeQuest.isCompleted = true;

        SetQuestActiveById(quests[newIndex].questModel.id);
        questIndex++;
    }

    public void SetQuestActiveById(string id)
    {
        var quest = quests.FirstOrDefault(_ => _.questModel.id == id);

        if(quest != null)
        {
            activeQuest = quest;
            questBox.SetActive(true);
            questText.text = activeQuest.questModel.questText;
        }
    }

    public bool CheckQuestCompletion(string id)
    {
        var quest = quests.FirstOrDefault(_ => _.questModel.id == id);

        if(quest == null)
        {
            return false;
        }

        return quest.isCompleted;
    }
}
