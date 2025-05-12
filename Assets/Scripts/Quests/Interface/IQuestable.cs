public interface IQuestable
{
    string TargetQuestID { get; }  // �������������, ��������� � ������� (��������, "zombie_kill", "potion_collect")
    int ProgressAmount { get; } // �� ������� ��������� �������� (������ 1, �� ����� ���� � ������)

    void InvokeProgress()
    {
        QuestEntity.Instance.HandleQuestProgress(this); // �������������� ����� ���������
    }
}
