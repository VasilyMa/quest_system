using System;
using System.Collections.Generic;
using System.Linq;

using Statement;

using UnityEngine;

public class QuestGiver : MonoBehaviour
{
    [SerializeField] List<QuestBase> _avaiableQuests;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            var list = _avaiableQuests.Take(3).Select(q => q.GetQuest()).ToList();
            
            QuestEntity.Instance.UpdateAvaibleQuestList(list);

            State.Instance.InvokeCanvas<QuestCanvas>().OpenPanel<QuestPanel>();
        }
    }
}
