using UnityEngine;

public class CollectableItem : MonoBehaviour, IQuestable
{
    public string TargetQuestID => "collect_gold";

    public int ProgressAmount => 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            QuestEntity.Instance.HandleQuestProgress(this);

            gameObject.SetActive(false);
        }
    }
}
