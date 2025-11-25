using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

[Serializable]
public class Quest {
    public QuestSO SO;
    public List<Queststep> Steps { get; private set; }
    public int Index { get; private set; }
    [NonSerialized] public Action<Quest> OnCompleted;
    public bool Completed { get; private set; } = false;
    PlayerJournalComponent _parttaker;

    public Quest(QuestSO data, PlayerJournalComponent parttaker, int stepindex = 0) {
        Index = stepindex;
        SO = data;
        Steps = new();
        _parttaker = parttaker;
        Steps = SO.Steps.Select(x => QuestFactory.Queststeps[x.GetType()].Invoke(x, parttaker, this)).ToList();
    }

    public async void Initialize()
    {
        await OnInitilize();
    }
    async Task OnInitilize()
    {
        await Task.Delay(1000);
    }

    public Queststep CurrentStep() => Steps[Index];

    public void StepComplete(Queststep step) {

        if (step != CurrentStep())
            return;

        Index++;
        if (Index >= Steps.Count) {
            Complete();
        }
        _parttaker.StepCompleted?.Invoke(step);
    }

    public void Complete() {
        Completed = true;
        OnCompleted?.Invoke(this);
    }
}