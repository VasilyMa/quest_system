using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IQuestable
{
    string TargetQuestID { get; }  // Идентификатор, связанный с квестом (например, "zombie_kill", "potion_collect")
    int ProgressAmount { get; } // На сколько увеличить прогресс (обычно 1, но может быть и больше)

    void InvokeProgress()
    {
        QuestEntity.Instance.HandleQuestProgress(this); // Автоматический вызов менеджера
    }
}
