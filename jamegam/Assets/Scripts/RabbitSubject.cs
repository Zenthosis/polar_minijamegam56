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
    private Animator myAnimator;
    private Shed shed;
    private Farm farm;

    private SpriteRenderer spriteRenderer;
    private bool isInShed = false;

    private void Awake()
    {
        rabbit = GetComponent<Rabbit>();
        myAnimator = GetComponentInChildren<Animator>();
        shed = FindAnyObjectByType<Shed>();
        farm = FindAnyObjectByType<Farm>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    private void OnEnable()
    {
        colliders = GetComponentsInChildren<Collider2D>();
        foreach (var col in colliders)
            col.enabled = false;

        StartCoroutine(MoveToShedThenDisable());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    // Called by Shed when a farm spot is available
    public void StartFarming()
    {
        targetArea = rabbit.farmLocation;
        spriteRenderer.enabled = true;
        isInShed = false;
        StartCoroutine(FarmingRoutine());
    }

    private IEnumerator MoveToShedThenDisable()
    {
        rabbit.ChangeState(RabbitState.Moving);

        Transform shedTransform = shed.transform;
        while (Vector2.Distance(transform.position, shedTransform.position) > arrivalThreshold)
        {
            rabbit.MoveInDirection((shedTransform.position - transform.position).normalized);
            yield return null;
        }

        rabbit.ChangeState(RabbitState.Idle);
        shed.Add(this);
        spriteRenderer.enabled = false;
        isInShed = true;
    }



    private IEnumerator FarmingRoutine()
    {
        if (targetArea != null)
        {
            rabbit.ChangeState(RabbitState.Moving);
            while (Vector2.Distance(transform.position, targetArea.position) > arrivalThreshold)
            {
                if (isInShed) yield break; // safety exit
                rabbit.MoveInDirection((targetArea.position - transform.position).normalized);
                yield return null;
            }
        }

        StartCoroutine(AutoFarm());

        // Phase 2: Patrol
        while (true)
        {
            if (isInShed) yield break; // safety exit
            myAnimator.SetBool("IsFarming", true);

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
        while (true)
        {
            farm.FarmCarrots(rabbit.Data.carrotGainPerYield);
            yield return new WaitForSeconds(rabbit.Data.yieldIntervals);
        }
    }
}