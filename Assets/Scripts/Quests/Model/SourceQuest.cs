using System;

using UnityEngine;

[System.Serializable]
public abstract class SourceQuest
{
    public Sprite Icon { get => icon; }
    [SerializeField] protected Sprite icon;
    public string Id { get => id; }
    [HideInInspector] public string id;

    public abstract string TargetID { get; }
    public string Title { get => title; }
    [SerializeField] protected string title;
    public string Description { get => description; }
    [SerializeField] protected string description;
    public bool IsCompleted { get => isCompleted; }
    protected bool isCompleted;
    public int Progress { get => progress; }
    protected int progress;
    public int TargetProgress { get => targetProgress; }
    [SerializeField] protected int targetProgress;

    public float CurrentProgress
    {
        get
        {
            return progress / (float)targetProgress;
        }
    }

    public event Action OnProgressChanged;
    public event Action OnCompleted;

    protected SourceQuest(SourceQuest data)
    {
        id = data.id;
        title = data.title;
        icon = data.icon;
        description = data.description;
        targetProgress = data.targetProgress;
    }
    public abstract SourceQuest Clone();
    public abstract void UpdateProgress(int amount);
    
    protected void CheckCompletion()
    {
        if (Progress >= TargetProgress)
            Complete();
    }

    protected virtual void Complete()
    {
        isCompleted = true;
        OnCompleted?.Invoke();
    }

    protected void NoticeProgressChanged()
    {
        OnProgressChanged?.Invoke();
    }
}