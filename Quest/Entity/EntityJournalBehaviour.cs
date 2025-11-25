using System.Collections.Generic;
using UnityEngine;


public class EntityJournalBehaviour : JournalBehaviour 
{
    public Sprite QuestMinimapMarker;
    public override EntityJournalComponent CreateJournal()
    {
        return new EntityJournalComponent(this, _quests);
    }
}