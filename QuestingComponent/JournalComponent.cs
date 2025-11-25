using System.Collections.Generic;

public class JournalComponent {
    public JournalComponent(UnityEngine.MonoBehaviour behaviour, List<QuestSO> quests){
        Quests = quests;
    }
    public List<QuestSO> Quests { get; set; } = new();
}