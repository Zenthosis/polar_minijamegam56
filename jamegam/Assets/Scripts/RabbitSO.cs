using UnityEngine;

[System.Serializable]
public struct RabbitData
{
    public string rabbitName;
    public float maxHealth;
    public float damage;
    public float attacksPerSecond;
    public float moveSpeed;
    public float patrolRange;
    public float idleTimeBetweenPatrols;
    public float conversionThreshold; // health % at which rabbit can be converted
}

[CreateAssetMenu(fileName = "NewRabbitData", menuName = "Rabbits/RabbitSO")]
public class RabbitSO : ScriptableObject
{
    [SerializeField] public RabbitData rabbitData;
}
