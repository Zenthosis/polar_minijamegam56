using TMPro;
using UnityEngine;

public class CarrotCountUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] Farm farm;

    private void Update()
    {
        text.text = farm.CurrentCarrotAmount.ToString("F2");
    }
}
