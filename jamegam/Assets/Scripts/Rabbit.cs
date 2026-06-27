using System;
using UnityEngine;

public enum RabbitState { Idle, Moving, Attacking, Converted }

public class Rabbit : MonoBehaviour
{
    [SerializeField] protected RabbitSO rabbitSO;

    public RabbitData Data => rabbitSO.rabbitData;
    public RabbitState CurrentState { get; private set; }
    public event Action OnSwitchSide;
    Animator myAnimator;
    public Transform farmLocation { get; private set; }

    private void Start()
    {
        myAnimator = GetComponentInChildren<Animator>();
    }

    public void Init(Transform farmLocation)
    {
        this.farmLocation = farmLocation;
    }

    public void ChangeState(RabbitState newState)
    {  
        if (CurrentState == newState) return;
        CurrentState = newState;
        //Debug.Log($"{gameObject.name} changed state to: {CurrentState}");
        if (CurrentState != RabbitState.Converted)
        {
            myAnimator.SetBool("IsAttacking", CurrentState == RabbitState.Attacking);
            myAnimator.SetBool("IsAttacking", CurrentState == RabbitState.Idle);
        }
        else 
        {
            myAnimator.SetBool("IsAttacking", false);
            myAnimator.SetBool("IsConverted", true);
        }
    }

    public void MoveInDirection(Vector2 direction)
    {
        transform.position += (Vector3)(direction.normalized * Data.moveSpeed * Time.deltaTime);
    }

    public void SwitchSide()
    {
        OnSwitchSide?.Invoke();
    }
}