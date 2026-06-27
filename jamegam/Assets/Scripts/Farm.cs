using UnityEngine;
using UnityEngine.EventSystems;

public class Farm : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private float clickAmount = 0.1f;
    [SerializeField] private GameObject notifPrefab;

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
        Instantiate(notifPrefab, transform.position, Quaternion.identity); // to be pooled.
        print("+ " + amount);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        FarmCarrots(clickAmount);
    }
}
