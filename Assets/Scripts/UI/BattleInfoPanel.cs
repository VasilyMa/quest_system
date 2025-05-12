using UnityEngine;
using UnityEngine.UI;
using System;
using Statement;

public class BattleInfoPanel : SourcePanel
{
    [SerializeField] Button _btnClose;

    public override void Init(SourceCanvas canvasParent)
    {
        base.Init(canvasParent);

    }

    public override void OnOpen(params Action[] onComplete)
    {
        base.OnOpen(AddCallback(onComplete, oncComplete));
    }

    void oncComplete()
    {
        OpenLayout<CurrentQuestLayout>();
    }

    void Close()
    {
        State.Instance.InvokeCanvas<BattleCanvas>();
    }

    public override void OnDipose()
    {
        base.OnDipose();
    }
}
