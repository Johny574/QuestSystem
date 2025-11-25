
using System.Collections.Generic;
using UnityEngine;

public abstract class JournalBehaviour : MonoBehaviour
{
    [SerializeField] protected List<QuestSO> _quests;
    public EntityJournalComponent Journal { get; private set; }
    protected void Awake()
    {
        Journal = CreateJournal();
    }

    public abstract EntityJournalComponent CreateJournal();
}