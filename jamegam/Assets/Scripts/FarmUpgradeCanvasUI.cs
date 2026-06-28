using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FarmUpgradeCanvasUI : MonoBehaviour
{
    [SerializeField] private Farm farm;
    [SerializeField] private TextMeshProUGUI bunnyCountText;
    [SerializeField] private TextMeshProUGUI upgradeCostText;
    [SerializeField] private Button upgradeBtn;

    private void Update()
    {
        bunnyCountText.text = $"{farm.RabbitCount}/{farm.MaxBunnies}";
        upgradeCostText.text = $"{farm.UpgradeCost}";
        upgradeBtn.interactable = farm.CanBeUpgraded;
    }
}