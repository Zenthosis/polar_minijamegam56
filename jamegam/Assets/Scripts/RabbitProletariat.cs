using UnityEngine;
using UnityEngine.Events;

public class RabbitProletariat : MonoBehaviour
{
    [Header("Combat")]
    [SerializeField] private float wallAttackRange = 1.5f;

    [Header("Events")]
    public UnityEvent<RabbitProletariat> onRabbitConverted;

    public float currentHealth { get; private set; }
    public float healthPercent => currentHealth / rabbit.Data.maxHealth;

    private Rabbit rabbit;
    private RabbitSubject rabbitSubject;
    private Wall wall;
    private float lastAttackTime;
    private float attackInterval;

    private void Awake()
    {
        rabbit = GetComponent<Rabbit>();
        rabbitSubject = GetComponent<RabbitSubject>();

        if (rabbitSubject != null)
            rabbitSubject.enabled = false;

        currentHealth = rabbit.Data.maxHealth;
        attackInterval = 1f / rabbit.Data.attacksPerSecond;
        wall = FindAnyObjectByType<Wall>();
    }

    private void Update()
    {
        if (wall == null) return;

        float distanceToWall = Vector2.Distance(transform.position, wall.transform.position);

        if (distanceToWall > wallAttackRange)
        {
            rabbit.ChangeState(RabbitState.Moving);
            rabbit.MoveInDirection(Vector2.right);
            return;
        }

        if (Time.time >= lastAttackTime + attackInterval)
        {
            rabbit.ChangeState(RabbitState.Attacking);
            wall.TakeDamage(rabbit.Data.damage);
            lastAttackTime = Time.time;
        }
        else
        {
            //rabbit.ChangeState(RabbitState.Idle);
        }
    }

    public void FeedCarrot(float amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0f, rabbit.Data.maxHealth);

        if (currentHealth <= 0f)
            SwitchSides();
    }

    public void SwitchSides()
    {
        GetComponentInChildren<SpriteRenderer>().color = Color.green;

        onRabbitConverted?.Invoke(this);
        rabbit.SwitchSide();
        rabbit.ChangeState(RabbitState.Converted);

        if (rabbitSubject != null)
            rabbitSubject.enabled = true;

        enabled = false;
    }
}