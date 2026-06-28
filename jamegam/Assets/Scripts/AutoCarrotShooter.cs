using System.Linq;
using UnityEngine;

using UnityEngine;

[RequireComponent(typeof(CarrotShooter))]
public class AutoCarrotShooter : MonoBehaviour
{
    [Header("Interval Increase")]
    [SerializeField] private float fireRate = 0.5f;          // shots per second
    [SerializeField] private float fireRateIncrease = 0.1f;
    [SerializeField] private float fireRateUpgradeCost = 5f;
    [SerializeField] private float fireRateUpgradeCostIncrease = 5f;

    [Header("Damage Increase")]
    [SerializeField] private float damageUpgradeCost = 5f;
    [SerializeField] private float damageUpgradeCostIncrease = 5f;
    [SerializeField] private float damageIncrease = 5f;

    private CarrotShooter carrotShooter;
    private Farm farm;
    private float timer;

    public float FireRate => fireRate;
    public float FireRateUpgradeCost => fireRateUpgradeCost;
    public float DamageUpgradeCost => damageUpgradeCost;
    public float CurrentDamage => carrotShooter.CurrentDamage;

    private void Start()
    {
        carrotShooter = GetComponent<CarrotShooter>();
        farm = FindAnyObjectByType<Farm>();
        timer = 1f / fireRate; // fire after first full interval
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 1f / fireRate)
        {
            timer = 0f;
            FindAndShootClosestRabbit();
        }
    }

    public void UpgradeFireRate()
    {
        if (!farm.HasEnoughCarrots(fireRateUpgradeCost)) return;
        farm.ReduceCarrots(fireRateUpgradeCost);
        fireRate += fireRateIncrease;
        fireRateUpgradeCost += fireRateUpgradeCostIncrease;
    }

    private void FindAndShootClosestRabbit()
    {
        RabbitProletariat[] rabbits = FindObjectsByType<RabbitProletariat>(FindObjectsSortMode.None)
            .Where(r => r.enabled)
            .ToArray();

        if (rabbits.Length == 0) return;

        RabbitProletariat nearest = null;
        float nearestX = float.MaxValue;

        foreach (var rabbit in rabbits)
        {
            float distX = Mathf.Abs(rabbit.transform.position.x - transform.position.x);
            if (distX < nearestX)
            {
                nearestX = distX;
                nearest = rabbit;
            }
        }

        if (nearest != null)
            carrotShooter.ShootCarrotFree(nearest);
    }

    public void UpgradeDamage()
    {
        if (!farm.HasEnoughCarrots(damageUpgradeCost)) return;
        farm.ReduceCarrots(damageUpgradeCost);
        carrotShooter.SetDamage(carrotShooter.CurrentDamage + damageIncrease);
        print("iNCREASED DAMAGE");
        damageUpgradeCost += damageUpgradeCostIncrease;
    }
}