using System.Collections;
using UnityEngine;

public class RabbitSubject : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private Transform targetArea;
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float arrivalThreshold = 0.2f;

    [Header("Patrol")]
    [SerializeField] private float patrolRange = 3f;    // +/- range around targetArea
    [SerializeField] private float minIdleTime = 1f;
    [SerializeField] private float maxIdleTime = 3f;

    private Collider2D[] _colliders;
    private bool _arrivedAtTarget = false;
    private float _patrolDestinationX;

    private void OnEnable()
    {
        // Disable all colliders so the converted rabbit doesn't interfere
        _colliders = GetComponentsInChildren<Collider2D>();
        foreach (var col in _colliders)
            col.enabled = false;

        _arrivedAtTarget = false;

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
            while (Vector2.Distance(transform.position, targetArea.position) > arrivalThreshold)
            {
                transform.position = Vector2.MoveTowards(
                    transform.position,
                    targetArea.position,
                    moveSpeed * Time.deltaTime
                );
                yield return null;
            }
        }

        _arrivedAtTarget = true;

        // Phase 2: Patrol randomly around the target area
        while (true)
        {
            float baseX = targetArea != null ? targetArea.position.x : transform.position.x;

            // Pick a random destination within patrolRange of the base position
            _patrolDestinationX = baseX + Random.Range(-patrolRange, patrolRange);
            Vector2 destination = new Vector2(_patrolDestinationX, transform.position.y);

            // Walk to destination
            while (Mathf.Abs(transform.position.x - _patrolDestinationX) > arrivalThreshold)
            {
                transform.position = Vector2.MoveTowards(
                    transform.position,
                    destination,
                    moveSpeed * Time.deltaTime
                );
                yield return null;
            }

            // Idle before next patrol
            float idleTime = Random.Range(minIdleTime, maxIdleTime);
            yield return new WaitForSeconds(idleTime);
        }
    }
}
