using UnityEngine;

[System.Serializable]
public struct RabbitData
{
    public string rabbitName;

    [Header("Proletariat")]
    public float maxHealth;
    public float damage;
    public float attacksPerSecond;
    public float moveSpeed;

    [Header("Subject")]
    public float patrolRange;
    public float idleTimeBetweenPatrols;
    public float carrotGainPerYield;
    public float yieldIntervals;
}

[CreateAssetMenu(fileName = "NewRabbitData", menuName = "Rabbits/RabbitSO")]
public class RabbitSO : ScriptableObject
{
    [SerializeField] public RabbitData rabbitData;
}
