using System.Collections.Generic;
using UnityEngine;

public class EntityJournalComponent {
    MonoBehaviour Behaviour;
    public EntityJournalComponent(MonoBehaviour behaviour, List<QuestSO> quests){
        Quests = quests;
        Behaviour = behaviour;
    }
    public List<QuestSO> Quests { get; set; } = new();
}