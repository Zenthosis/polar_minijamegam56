using UnityEngine;

/// <summary>
/// Automatically fires at the nearest RabbitProletariat on a set interval.
/// Attach alongside CarrotShooter on the same GameObject.
/// </summary>
[RequireComponent(typeof(CarrotShooter))]
public class AutoCarrotShooter : MonoBehaviour
{
    [SerializeField] private float fireInterval = 2f;

    private CarrotShooter _carrotShooter;
    private float _timer;

    private void Start()
    {
        _carrotShooter = GetComponent<CarrotShooter>();
        _timer = fireInterval; // fire immediately on first interval
    }

    //private void Update()
    //{
    //    _timer += Time.deltaTime;

    //    if (_timer >= fireInterval)
    //    {
    //        _timer = 0f;
    //        bool hit = _carrotShooter.FindAndShootClosestRabbit();

    //        if (!hit)
    //            Debug.Log("[AutoCarrotShooter] No rabbit in range to shoot at.");
    //    }
    //}


    ///// <summary>
    ///// Finds the closest RabbitProletariat within detectionRadius and shoots at it.
    ///// Returns true if a target was found and shot at.
    ///// </summary>
    //public bool FindAndShootClosestRabbit()
    //{
    //    Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, detectionRadius, rabbitLayer);

    //    if (hits.Length == 0)
    //        return false;

    //    RabbitProletariat closestRabbit = null;
    //    float closestDistance = float.MaxValue;

    //    foreach (var hit in hits)
    //    {
    //        RabbitProletariat rabbit = hit.GetComponent<RabbitProletariat>();
    //        if (rabbit == null || !rabbit.enabled) continue;

    //        float dist = Vector2.Distance(transform.position, hit.transform.position);
    //        if (dist < closestDistance)
    //        {
    //            closestDistance = dist;
    //            closestRabbit = rabbit;
    //        }
    //    }

    //    if (closestRabbit == null)
    //        return false;

    //    ShootCarrot(closestRabbit.transform);
    //    return true;
    //}
}
