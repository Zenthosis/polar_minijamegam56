using TMPro;
using UnityEngine;

public class ShedCanvasUI : MonoBehaviour
{
    [SerializeField] private Shed shed;
    [SerializeField] private TextMeshProUGUI bunnyCountText;

    private void Update()
    {
        bunnyCountText.text = $"{shed.BunnyCount}";
    }
}