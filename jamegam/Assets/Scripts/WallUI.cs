using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WallUI : MonoBehaviour
{
    [SerializeField] private Wall wall;
    [SerializeField] private Farm farm;
    [SerializeField] private Button healButton;
    [SerializeField] private TextMeshProUGUI healCostText;

    private void Start()
    {
        healCostText.text = $"{wall.HealCost}";
        healButton.onClick.AddListener(() => wall.Heal(farm));
    }

    private void Update()
    {
        healButton.interactable = farm.HasEnoughCarrots(wall.HealCost);
    }
}