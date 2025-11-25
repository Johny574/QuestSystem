using System;
using UnityEngine;

[Serializable]
public abstract class Queststep  {
    public QueststepSO SO;
    protected QuestingComponent _parttaker;
    Quest _quest;

    protected Queststep(QueststepSO data, QuestingComponent parttaker, Quest quest) {
        SO = data;
        _parttaker = parttaker;
        _quest = quest;
    }

    public virtual void Complete() {
        _quest.StepComplete(this);
    }
    
    public abstract Vector2 Closestpoint(Vector2 origin);
}