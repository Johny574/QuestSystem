using System.Collections.Generic;
using UnityEngine;


public class JournalBehaviour : MonoBehaviour
{
    [SerializeField] List<QuestSO> _quests;
    public Sprite QuestMinimapMarker;

    public JournalComponent Journal { get; private set; }
    void Awake()
    {
        Journal = new(this, _quests);
    }
}