using System;

[Serializable]
public class QuestData
{
    public string GUID;
    public int CurrentStep;

    public QuestData(string gUID, int currentStep) {
        GUID = gUID;
        CurrentStep = currentStep;
    }
}