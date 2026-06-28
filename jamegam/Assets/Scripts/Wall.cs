using DG.Tweening;
using System;
using UnityEngine;

public class Wall : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    [SerializeField] private SpriteRenderer visuals;
    [SerializeField] private float healAmount = 20f;
    [SerializeField] private float healCost = 5f;
    [SerializeField] private float costIncreaseAfterHeal = 2f;

    public event Action OnWallBroken;

    public float MaxHealth => maxHealth;
    public float HealCost => healCost;
    public float HealAmount => healAmount;
    public float currentHealth { get; private set; }

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        TakeHitVisuals();

        if (currentHealth <= 0)
            OnWallBroken?.Invoke();
    }

    public void Heal(Farm farm)
    {
        print("Heal raeched!");
        if (!farm.HasEnoughCarrots(healCost)) return;

        print("Heal!");
        farm.ReduceCarrots(healCost);
        currentHealth = Mathf.Min(currentHealth + healAmount, maxHealth);
        healCost += costIncreaseAfterHeal;
    }

    private void TakeHitVisuals()
    {
        transform.DOPunchScale(Vector3.one * 0.2f, 0.1f, 0, 0f);
        visuals.DOColor(new Color(0.7f, 0.7f, 0.7f), 0.05f)
            .OnComplete(() => visuals.DOColor(Color.white, 0.05f));
    }
}