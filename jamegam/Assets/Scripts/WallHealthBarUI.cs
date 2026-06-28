using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class WallHealthBarUI : MonoBehaviour
{
    [SerializeField] private Wall wall;
    [SerializeField] private Slider slider;
    [SerializeField] private Image fillImage;

    private float lastHealth;

    private void Start()
    {
        lastHealth = wall.currentHealth;
    }

    private void Update()
    {
        float healthPercent = wall.currentHealth / wall.MaxHealth;
        slider.value = healthPercent;
        fillImage.color = Color.Lerp(Color.red, Color.green, healthPercent);

        if (wall.currentHealth != lastHealth)
        {
            lastHealth = wall.currentHealth;
            slider.transform.DOPunchScale(Vector3.one * 0.1f, 0.1f, 0, 0f);
        }
    }
}