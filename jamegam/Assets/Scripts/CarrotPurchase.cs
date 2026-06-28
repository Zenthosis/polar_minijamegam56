using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CarrotPurchase : MonoBehaviour
{
    [SerializeField] private float cost;
    [SerializeField] private Farm farm;
    [SerializeField] private Button button;
    [SerializeField] private UnityEvent onPurchase;
    [SerializeField] private TextMeshProUGUI costText;

    private void Start()
    {
        button.onClick.AddListener(Purchase);
        costText.text = cost.ToString();
    }

    private void Update()
    {
        button.interactable = farm.HasEnoughCarrots(cost);
    }

    private void Purchase()
    {
        if (!farm.HasEnoughCarrots(cost)) return;
        farm.ReduceCarrots(cost);
        onPurchase.Invoke();
        Destroy(gameObject);
    }
}