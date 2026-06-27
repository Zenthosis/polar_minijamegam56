using UnityEngine;
using UnityEngine.UI;

public class WallHealthBarUI : MonoBehaviour
{
    [SerializeField] private Wall wall;
    [SerializeField] private Slider slider;

    private void Update()
    {
        slider.value = (wall.currentHealth / wall.MaxHealth);    
    }
}
