using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Pool;

public class Farm : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private float clickAmount = 0.1f;
    [SerializeField] private GameObject notifPrefab;

    private ObjectPool<NotifPopup> notifPrefabPool;

    private void Awake()
    {
        notifPrefabPool = new ObjectPool<NotifPopup>(
            createFunc: () => Instantiate(notifPrefab).GetComponent<NotifPopup>(),
            actionOnGet: popUp => popUp.gameObject.SetActive(true),
            actionOnRelease: popUp => popUp.gameObject.SetActive(false),
            actionOnDestroy: popUp => Destroy(popUp.gameObject),
            collectionCheck: true,  // throws if you release something already in the pool
            defaultCapacity: 10,
            maxSize: 20
        );
    }

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
        SpawnPopUp(amount);
    }

    private void SpawnPopUp(float amount)
    {
        NotifPopup popup = notifPrefabPool.Get();
        popup.Init(notifPrefabPool, $"+ {amount}");
        popup.transform.position = transform.position;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        FarmCarrots(clickAmount);
    }
}
