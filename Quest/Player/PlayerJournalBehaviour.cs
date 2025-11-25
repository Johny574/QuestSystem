

using System.Collections.Generic;
using UnityEngine;

public class PlayerJournalBehaviour : MonoBehaviour
{
    public PlayerJournalComponent Questing { get; set; }
    [SerializeField] List<QuestSO> _quests = new();
    [SerializeField] List<QuestSO> _startingQuests = new();
    void Awake()
    {
        Questing = new(this, _startingQuests);
    }

    void Start() {
        Questing.Initilize(_quests);
    }
}