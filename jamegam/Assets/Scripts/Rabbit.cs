using System;
using UnityEngine;

public enum RabbitState { Idle, Moving, Attacking, Converted }

public class Rabbit : MonoBehaviour
{
    [SerializeField] public float moveSpeedBun; //////////////////////
    [SerializeField] protected float moveSpeedBase; /////////////////////
    [SerializeField] protected RabbitSO rabbitSO;

    public RabbitData Data => rabbitSO.rabbitData;
    public RabbitState CurrentState { get; private set; }
    public event Action OnSwitchSide;
    private Animator myAnimator;
    public Transform farmLocation { get; private set; }

    private void Start()
    {
        myAnimator = GetComponentInChildren<Animator>();
        moveSpeedBase = Data.moveSpeed;/////////////////
        moveSpeedBun = moveSpeedBase;///////////////
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
        transform.position += (Vector3)(direction.normalized * moveSpeedBun * Time.deltaTime);
    }

    public void SwitchSide()
    {
        OnSwitchSide?.Invoke();
    }
}