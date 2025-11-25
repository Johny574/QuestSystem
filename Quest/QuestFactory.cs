using System;
using System.Collections.Generic;

public static class QuestFactory
{
    public static Dictionary<Type, Func<QueststepSO, PlayerJournalComponent, Quest, Queststep>> Queststeps = new() {
        { typeof(CollectItemQuestStepSO),         (data, partaker, quest) => new CollectItemQueststep(data,  partaker, quest)},
    };
}
