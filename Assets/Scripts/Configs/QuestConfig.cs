using System.Collections;
using System.Collections.Generic;

using UnityEngine;

[CreateAssetMenu(fileName = "QuestConfig", menuName = "Config/Quest")]
public class QuestConfig : Config
{
    public List<QuestBase> QuestBaseList;
    private Dictionary<string, QuestBase> QuestBaseDictionary;

    public override IEnumerator Init()
    {
        QuestBaseDictionary  = new Dictionary<string, QuestBase>();

        foreach (var quest in QuestBaseList)
        {
            QuestBaseDictionary.Add(quest.Quest.Id, quest);
        }

        yield return null;
    }

    public bool TryGetQuestByID(string id, out QuestBase quest)
    {
        quest = null;

        if (QuestBaseDictionary.ContainsKey(id))
        {
            quest = QuestBaseDictionary[id];
            return true;
        }

        return false;
    }
}
