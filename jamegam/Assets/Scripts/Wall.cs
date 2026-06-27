using DG.Tweening;
using System;
using UnityEngine;

public class Wall : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    [SerializeField] private SpriteRenderer visuals;

    public event Action OnWallBroken;

    public float MaxHealth => maxHealth;
    public float currentHealth { get; private set; }
    private void Awake()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        TakeHitVisuals();
        print($"Took {damage} damage!");

        if(currentHealth <= 0)
        {
            OnWallBroken?.Invoke();
        }
    }

    private void TakeHitVisuals()
    {
        transform.DOPunchScale(Vector3.one * 0.2f, 0.1f, 0, 0f);
        visuals.DOColor(new Color(0.7f, 0.7f, 0.7f), 0.05f)
            .OnComplete(() => visuals.DOColor(Color.white, 0.05f));
    }
}
