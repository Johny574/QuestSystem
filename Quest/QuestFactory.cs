using System;
using System.Collections.Generic;
using UnityEngine;

public static class QuestFactory
{

    public static Dictionary<Type, Func<QueststepSO, QuestingComponent, Quest, Queststep>> Queststeps = new() {
        { typeof(CollectItemQuestStepData),         (data, partaker, quest) => new CollectItemQueststep(data,  partaker, quest)},
    };



}
