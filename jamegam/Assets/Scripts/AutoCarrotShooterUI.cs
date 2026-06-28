using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AutoCarrotShooterUI : MonoBehaviour
{
    [SerializeField] private AutoCarrotShooter shooter;
    [SerializeField] private Farm farm;

    [Header("Damage")]
    [SerializeField] private TextMeshProUGUI currentDamageText;
    [SerializeField] private TextMeshProUGUI damageUpgradeCostText;
    [SerializeField] private Button damageUpgradeButton;

    [Header("Fire Rate")]
    [SerializeField] private TextMeshProUGUI currentIntervalText;
    [SerializeField] private TextMeshProUGUI intervalUpgradeCostText;
    [SerializeField] private Button intervalUpgradeButton;

    private void Start()
    {
        damageUpgradeButton.onClick.AddListener(shooter.UpgradeDamage);
        intervalUpgradeButton.onClick.AddListener(shooter.UpgradeFireRate);
    }

    private void Update()
    {
        currentDamageText.text = $"{shooter.CurrentDamage}";
        damageUpgradeCostText.text = $"{shooter.DamageUpgradeCost}";
        damageUpgradeButton.interactable = farm.HasEnoughCarrots(shooter.DamageUpgradeCost);

        currentIntervalText.text = $"{shooter.FireRate:F1}/s";
        intervalUpgradeCostText.text = $"{shooter.FireRateUpgradeCost}";
        intervalUpgradeButton.interactable = farm.HasEnoughCarrots(shooter.FireRateUpgradeCost);
    }
}