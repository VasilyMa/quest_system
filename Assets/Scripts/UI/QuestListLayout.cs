public class QuestListLayout : SourceLayout
{
    public override SourceLayout Init(SourcePanel panel)
    {
        return base.Init(panel); 
    }

    public override void OnOpen()
    {
        if (QuestEntity.Instance.AvaibleQuestList.Count > 0)
        {
            for (int i = 0; i < _slots.Length; i++)
            {
                if (i >= QuestEntity.Instance.AvaibleQuestList.Count)
                {
                    _slots[i].UpdateView();
                }
                else
                {
                    var slot = _slots[i].GetSlot<QuestSlot>();
                    slot.data = QuestEntity.Instance.AvaibleQuestList[i];
                    slot.UpdateView();
                }
            }
        }
        else
        {
            for (int i = 0; i < _slots.Length; i++)
            {
                _slots[i].UpdateView();
            }
        }

        base.OnOpen();
    }

    public override void Dispose()
    {
        base.Dispose();
    }
}
