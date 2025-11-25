using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class QuestingComponent
{
    public List<Quest> ActiveQuests { get; set; } = new();
    public List<Quest> Completed { get; set; } = new();
    public Action<Queststep> StepCompleted;
    public MonoBehaviour Behaviour;

    public QuestingComponent(MonoBehaviour behaviour, List<QuestSO> startingQuests)
    {
        ActiveQuests = new(startingQuests.Select(x => new Quest(x, this)));
        StepCompleted += OnStepCompleted;
        Behaviour = behaviour;
    }

    private void OnStepCompleted(Queststep step)
    {
        DropRewards(step.SO.ItemRewards, step.SO.CurrencyRewards, step.SO.XpReward, Behaviour.transform.position);
    }

    public void Initilize(List<QuestSO> quests)
    {
        foreach (var quest in quests)
            Add(quest);
    }

    public void Add(QuestSO data, int stepindex=0)
    {
        Quest quest = new Quest(data, this, stepindex);
        ActiveQuests.Add(quest);
        quest.OnCompleted += OnQuestCompleted;
        quest.Initialize();
    }

    public void Remove(Quest quest) {
        ActiveQuests.Remove(quest);
        // Removed?.Invoke(quest);
        quest.OnCompleted -= OnQuestCompleted;
    }

    void OnQuestCompleted(Quest quest) {
        Completed.Add(quest);
        Remove(quest);
        
    }

    void DropRewards(List<ItemStack> items, int currency, float _xpReward, Vector3 position)
    {
        // xp 
        // var n = _xpReward- (_xpReward % Modifiers.MaxXPOrbSize);
        // for (int i = 0; i < (n/ Modifiers.MaxXPOrbSize); i++)
        //     new ExperienceCommands.DropCommand(Modifiers.MaxXPOrbSize, Behaviour.transform.position).Execute();

        // new ExperienceCommands.DropCommand(_xpReward % Modifiers.MaxXPOrbSize, Behaviour.transform.position).Execute();

        // items
        // for (int i = 0; i < items.Count; i++)
        //     ItemFactory.Instance.DropItem(Behaviour.transform.position, items[i]);

        // currency
        // CoinFactory.Instance.Drop(Behaviour.transform.position, currency);
    }

    public QuestData[] Save() => ActiveQuests.Select(x => new QuestData(x.SO.GUID, x.Index)).ToArray();

    public void Load(QuestData[] save) {
        ActiveQuests = new();
        for (int i = 0; i < save.Length; i++) {
            QuestData questdata = save[i]; // keep this reference in memory

            UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationHandle<QuestSO> QuestSO = Addressables.LoadAssetAsync<QuestSO>(new AssetReference(questdata.GUID));
            QuestSO.Completed += (questso) => {
                if (questso.Status == UnityEngine.ResourceManagement.AsyncOperations.AsyncOperationStatus.Failed)
                    throw new System.Exception($"Failed to load asset {questdata.GUID}");

                Add(questso.Result, questdata.CurrentStep);
            };
        }
    }
}