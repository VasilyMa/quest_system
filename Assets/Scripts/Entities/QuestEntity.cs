using System.Collections.Generic;

public class QuestEntity : SourceEntity
{
    public static QuestEntity Instance;
    private Dictionary<string, SourceQuest> _playerQuest;

    public List<SourceQuest> AvaibleQuestList { get; private set; }

    public QuestEntity()
    {
        Instance = this;
        _playerQuest = new Dictionary<string, SourceQuest>();
        AvaibleQuestList = new List<SourceQuest>();
    }

    public override SourceEntity Init()
    {
        var questConfig = ConfigModule.GetConfig<QuestConfig>();

        return this;
    }

    public bool TryAddQuest(SourceQuest sourceQuest)
    {
        if (_playerQuest.ContainsKey(sourceQuest.Id))
        {
            return false;
        }

        _playerQuest.Add(sourceQuest.TargetID, sourceQuest);  

        return true;
    }

    public void UpdateAvaibleQuestList(List<SourceQuest> list)
    {
        AvaibleQuestList.Clear();

        foreach (var item in list)
        {
            if (_playerQuest.ContainsKey(item.TargetID)) continue;

            AvaibleQuestList.Add(item);
        }
    }

    public void HandleQuestProgress(IQuestable questable)
    {
        string questID = questable.TargetQuestID;

        if (_playerQuest.TryGetValue(questID, out SourceQuest value))
        {
            value.UpdateProgress(questable.ProgressAmount);
        }
    }
}
