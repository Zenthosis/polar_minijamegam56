using UnityEngine;
using UnityEngine.Events;

public class RabbitProletariat : MonoBehaviour
{
    [SerializeField] private RabbitSO rabbitSO;
    [SerializeField] private float wallAttackableRange;
    public UnityEvent<RabbitProletariat> onRabbitConverted;

    private float _currentHealth;
    private RabbitSubject _rabbitSubject;
    private Wall wall;

    //AttackTimer
    private float lastAttackTime;
    private float secondsInBetweenAttacks;

    private void Awake()
    {
        _rabbitSubject = GetComponent<RabbitSubject>();

        if (_rabbitSubject != null)
            _rabbitSubject.enabled = false;

        _currentHealth = rabbitSO.rabbitData.maxHealth;
        wall = FindAnyObjectByType<Wall>();
        secondsInBetweenAttacks = rabbitSO.rabbitData.attacksPerSecond / 1f;
    }

    private void Update()
    {
        while (Vector3.Distance(transform.position, wall.transform.position) >= wallAttackableRange)
        {
            MoveRight();
            return;
        }

        //We've hit the wall. time to do damage.
        if(Time.time >= lastAttackTime + secondsInBetweenAttacks)
        {
            wall.TakeDamage(rabbitSO.rabbitData.damage);
            lastAttackTime = Time.time;
        }
    }

    private void MoveRight()
    {
        transform.position += transform.right * rabbitSO.rabbitData.moveSpeed * Time.deltaTime;
    }

    private void TakeDamage(float damageAmount)
    {
        _currentHealth -= damageAmount;
        _currentHealth = Mathf.Clamp(_currentHealth, 0f, rabbitSO.rabbitData.maxHealth);

        float healthPercent = _currentHealth / rabbitSO.rabbitData.maxHealth;
        Debug.Log($"[RabbitProletariat] {rabbitSO.rabbitData.rabbitName} took {damageAmount} damage. HP: {_currentHealth:F1} ({healthPercent * 100:F0}%)");

        if (_currentHealth <= 0f)
        {
            Debug.Log($"[RabbitProletariat] {rabbitSO.rabbitData.rabbitName} has been defeated.");
        }
    }

    public void FeedCarrot(float damageAmount)
    {
        TakeDamage(damageAmount);
    }

    public void SwitchSides()
    {
        Debug.Log($"[RabbitProletariat] {rabbitSO.rabbitData.rabbitName} has switched sides!");

        onRabbitConverted?.Invoke(this);

        if (_rabbitSubject != null)
            _rabbitSubject.enabled = true;

        this.enabled = false;
    }

    // Expose rabbit data for external systems (e.g. CarrotShooter targeting)
    public RabbitData GetRabbitData() => rabbitSO.rabbitData;
}
