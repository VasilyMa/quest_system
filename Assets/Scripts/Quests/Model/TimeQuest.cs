public class TimeQuest : SourceQuest
{
    public override string TargetID => targetKeyID;

    [UnityEngine.SerializeField] protected string targetKeyID;

    public TimeQuest(TimeQuest data) : base(data: data)
    {
        targetKeyID = data.targetKeyID;
    }

    public override SourceQuest Clone()
    {
        return new TimeQuest(this);
    }

    public override void UpdateProgress(int amount)
    {
        if (IsCompleted) return;

        progress += amount;

        NoticeProgressChanged();
        CheckCompletion();
    }
}
