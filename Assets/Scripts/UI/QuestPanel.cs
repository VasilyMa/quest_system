using System;

using Statement;

using UnityEngine;
using UnityEngine.UI;

public class QuestPanel : SourcePanel
{
    [SerializeField] Button _btnClose;
    
    public override void Init(SourceCanvas canvasParent)
    {
        _btnClose.onClick.AddListener(Close);
        base.Init(canvasParent);
    }

    public override void OnOpen(params Action[] onComplete)
    {
        base.OnOpen(AddCallback(onComplete, oncComplete));
    }

    void oncComplete()
    {
        OpenLayout<QuestListLayout>();
    }

    void Close()
    {
        State.Instance.InvokeCanvas<BattleCanvas>().OpenPanel<BattleInfoPanel>();
    }

    public override void OnDipose()
    {
        _btnClose.onClick.RemoveAllListeners();
        base.OnDipose();
    }
}
