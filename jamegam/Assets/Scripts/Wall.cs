using DG.Tweening;
using UnityEngine;

public class Wall : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    [SerializeField] private SpriteRenderer visuals;
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
    }

    private void TakeHitVisuals()
    {
        transform.DOPunchScale(Vector3.one * 0.2f, 0.1f, 0, 0f);
        visuals.DOColor(new Color(0.7f, 0.7f, 0.7f), 0.05f)
            .OnComplete(() => visuals.DOColor(Color.white, 0.05f));
    }
}
