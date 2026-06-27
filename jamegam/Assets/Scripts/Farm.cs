using UnityEngine;
using UnityEngine.EventSystems;

public class Farm : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private float clickAmount = 0.1f;

    public float CurrentCarrotAmount { get; private set; }

    public bool HasEnoughCarrots(float amount)
    {
        return CurrentCarrotAmount >= amount;
    }

    public void ReduceCarrots(float amount)
    {
        CurrentCarrotAmount -= amount;
    }

    public void FarmCarrots(float amount)
    {
        CurrentCarrotAmount += amount;
        print("+ " + amount);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        FarmCarrots(clickAmount);
    }
}
