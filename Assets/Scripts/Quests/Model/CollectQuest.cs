public class CollectQuest : SourceQuest
{
    public override string TargetID => targetKeyID;

    [UnityEngine.SerializeField] protected string targetKeyID;

    public CollectQuest(CollectQuest data) : base(data: data)
    {
        targetKeyID = data.targetKeyID;
    }

    public override SourceQuest Clone()
    {
        return new CollectQuest(this);
    }

    public override void UpdateProgress(int amount)
    {
        if (IsCompleted) return;

        progress += amount;

        NoticeProgressChanged();
        CheckCompletion();
    }
}
