using UnityEngine;

[CreateAssetMenu(fileName = "NewQuest", menuName = "Quest/NewQuest")]
public class QuestBase : ScriptableObject, ISerializationCallbackReceiver
{
    [SerializeReference] public SourceQuest Quest;

    public SourceQuest GetQuest()
    {
        return Quest.Clone();
    }

    public void OnAfterDeserialize()
    {

    }

    public void OnBeforeSerialize()
    {
        if (Quest != null)
        {
            Quest.id = name;
        }
    }
}
