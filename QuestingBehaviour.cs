

using System.Collections.Generic;
using UnityEngine;

public class QuestingBehaviour : MonoBehaviour
{
    public QuestingComponent Questing { get; set; }
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