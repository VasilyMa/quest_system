using UnityEngine;
using UnityEngine.UI;

public class QuestSlot : SourceSlot
{
    [HideInInspector] public SourceQuest data;
    [SerializeField] private Text _title;
    [SerializeField] private Text _description;

    public override SourceSlot Init(SourceLayout layout)
    {
        base.Init(layout);
        SetView(false);
        return this;
    }

    public override void OnClick()
    {
        if (QuestEntity.Instance.TryAddQuest(data))
        {
            _btnClick.interactable = false;
            data = null;
            SetView(false);
        }
    }
    public override void OnClose()
    {

    }

    public override void UpdateView()
    {
        if (data != null)
        {
            SetView(true);

            _btnClick.interactable = true;
            _icon.sprite = data.Icon;
            _title.text = data.Title;
            _description.text = $"{data.Description} всего {data.TargetProgress}";
        }
        else
        {
            SetView(false);
        }
    }

    void SetView(bool value)
    {
        _icon.enabled = value;
        _background.enabled = value;
        _title.enabled = value;
    }
}
