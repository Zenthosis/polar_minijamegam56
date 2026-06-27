using UnityEngine;

public enum RabbitState { Idle, Moving, Attacking }

public class Rabbit : MonoBehaviour
{
    [SerializeField] protected RabbitSO rabbitSO;

    public RabbitData Data => rabbitSO.rabbitData;
    public RabbitState CurrentState { get; private set; }

    public void ChangeState(RabbitState newState)
    {
        if (CurrentState == newState) return;
        CurrentState = newState;
    }

    public void MoveInDirection(Vector2 direction)
    {
        transform.position += (Vector3)(direction.normalized * Data.moveSpeed * Time.deltaTime);
    }
}