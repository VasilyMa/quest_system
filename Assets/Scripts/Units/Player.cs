using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    private Vector3 targetPosition;
    private bool isMoving = false;
    private LivingTimer timer;
    private float livingTimer;

    private void Start()
    {
        timer = new LivingTimer();
    }

    void Update()
    {
        HandleInput();
        MoveToTarget();

        if (livingTimer > 0)
        {
            livingTimer -= Time.deltaTime;
        }
        else
        {
            livingTimer = 1f;

            QuestEntity.Instance.HandleQuestProgress(timer);
        }
    }

    private void HandleInput()
    {
        if (Input.GetMouseButtonDown(0)) // ËÊÌ
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                targetPosition = new Vector3(hit.point.x, 0.5f, hit.point.z);
                isMoving = true;
            }
        }
    }

    private void MoveToTarget()
    {
        if (!isMoving) return;

        Vector3 direction = (targetPosition - transform.position).normalized;
        float distance = Vector3.Distance(transform.position, targetPosition);

        if (distance > 0.1f)
        {
            transform.position += direction * speed * Time.deltaTime;
        }
        else
        {
            isMoving = false;
        }
    }
}

public class LivingTimer : IQuestable
{
    public string TargetQuestID => "timer";

    public int ProgressAmount => 1;
}