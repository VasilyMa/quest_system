public class KillQuest : SourceQuest
{
    public override string TargetID => targetKeyID;

    [UnityEngine.SerializeField] protected string targetKeyID;

    public KillQuest(KillQuest data) : base(data: data)
    {
        targetKeyID = data.targetKeyID;
    }

    public override SourceQuest Clone()
    {
        return new KillQuest(this);
    }

    public override void UpdateProgress(int amount)
    {
        if(IsCompleted) return;

        progress += amount;

        NoticeProgressChanged();
        CheckCompletion();
    }
}
