using System.Collections;

using UnityEngine;

public class EnemyUnit : MonoBehaviour, IQuestable
{
    public string QuestKeyID;
    public string TargetQuestID => QuestKeyID;
    public int ProgressAmount => 1;

    private float speed;
    private float timeToRun;
    float time;
    float damageInterval = 0.25f;
    int health = 3;
    bool isDie;
    bool isInDamageZone;
    Vector3 targetToMove;

    public void Init()
    {
        speed = Random.Range(1, 3f);
        timeToRun = Random.Range(2, 10f);

        var parent = GameObject.FindWithTag("Units");

        transform.SetParent(parent.transform);
    }

    public void Run()
    {
        if (isDie) return;

        time -= Time.deltaTime;
        
        if (time <= 0)
        {
            if (FindTargetMove(GetRandomPointAround(transform.position, 100f)))
            {
                time = timeToRun;
            }
        }

        Move();
    }

    void Move()
    {
        Vector3 direction = (targetToMove - transform.position).normalized;
        float distance = Vector3.Distance(transform.position, targetToMove);

        if (distance > 0.1f)
        {
            transform.position += direction * speed * Time.deltaTime;
        }
    }

    public void TakeDamage()
    {
        health -= 1;
        
        if (health <= 0)
        {
            isDie = true;
            gameObject.SetActive(false);
        }
    }

    bool FindTargetMove(Vector3 point)
    {
        // Поднимаем точку немного вверх, чтобы луч точно попал вниз
        Vector3 rayOrigin = point + Vector3.up * 5f;
        float maxDistance = 10f;

        if (Physics.Raycast(rayOrigin, Vector3.down, out RaycastHit hit, maxDistance))
        {
            targetToMove = hit.point;
            return true;
        }
        // Проверяем, есть ли под точкой земля (ground)
        return false;
    }
    Vector3 GetRandomPointAround(Vector3 center, float radius)
    {
        Vector2 randomOffset = Random.insideUnitCircle * radius;
        return new Vector3(center.x + randomOffset.x, center.y, center.z + randomOffset.y);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isInDamageZone = true;
            StartCoroutine(StartDamageEvent());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isInDamageZone = false;
        }
    }

    IEnumerator StartDamageEvent()
    {
        while (isInDamageZone)
        {
            health--;

            if (health <= 0)
            {
                health = 0; // Чтобы здоровье не ушло в минус
                ((IQuestable)this).InvokeProgress();
                gameObject.SetActive(false);
                yield break; // Выходим из корутины, если здоровье закончилось
            }

            yield return new WaitForSeconds(damageInterval); // Ждём заданный интервал
        }
    }
}
