using System.Collections;
using UnityEngine;

public class RabbitSubject : MonoBehaviour
{
    [Header("Patrol")]
    private Transform targetArea;
    [SerializeField] private float patrolRange = 3f;
    [SerializeField] private float minIdleTime = 1f;
    [SerializeField] private float maxIdleTime = 3f;
    [SerializeField] private float arrivalThreshold = 0.2f;

    private Rabbit rabbit;
    private Collider2D[] colliders;
    private Animator myAnimator;////////////////

    private Farm farm;

    private void Start()
    {
        myAnimator = GetComponentInChildren<Animator>();//////////
    }

    private void Awake()
    {
        rabbit = GetComponent<Rabbit>();
    }

    private void OnEnable()
    {
        farm = FindAnyObjectByType<Farm>();

        colliders = GetComponentsInChildren<Collider2D>();
        foreach (var col in colliders)
            col.enabled = false;

        targetArea = rabbit.farmLocation;
        print("target area: " + targetArea);
        print("farmLocation area: " + rabbit.farmLocation);

        StartCoroutine(MoveToTargetThenPatrol());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    private IEnumerator MoveToTargetThenPatrol()
    {
        // Phase 1: Move to target area
        if (targetArea != null)
        {
            rabbit.ChangeState(RabbitState.Moving);

            while (Vector2.Distance(transform.position, targetArea.position) > arrivalThreshold)
            {
                rabbit.MoveInDirection((targetArea.position - transform.position).normalized);
                yield return null;
            }
        }

        StartCoroutine(AutoFarm());

        // Phase 2: Patrol
        while (true)
        {
            myAnimator.SetBool("IsFarming",true);/////////////////////////////////
            float baseX = targetArea != null ? targetArea.position.x : transform.position.x;
            float destX = baseX + Random.Range(-patrolRange, patrolRange);
            Vector2 destination = new Vector2(destX, transform.position.y);

            rabbit.ChangeState(RabbitState.Moving);

            while (Mathf.Abs(transform.position.x - destX) > arrivalThreshold)
            {
                rabbit.MoveInDirection((destination - (Vector2)transform.position).normalized);
                yield return null;
            }

            rabbit.ChangeState(RabbitState.Idle);
            yield return new WaitForSeconds(Random.Range(minIdleTime, maxIdleTime));
        }
    }

    private IEnumerator AutoFarm()
    {
        while(true)
        {
            farm.FarmCarrots(rabbit.Data.carrotGainPerYield);
            yield return new WaitForSeconds(rabbit.Data.yieldIntervals);
        }
    }
}