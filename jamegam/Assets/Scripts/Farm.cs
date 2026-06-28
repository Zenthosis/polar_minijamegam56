using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Pool;

public class Farm : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private float clickAmount = 0.1f;
    [SerializeField] private GameObject notifPrefab;
    [SerializeField] private float randomXRangeForPopups;

    private ObjectPool<NotifPopup> notifPrefabPool;
    private int carrotUnits; // 1 unit = 0.1 carrot 
    // 1 carrot unit is = 0.1 carrots. gotta do this because floating point imprecision.

    public float CurrentCarrotAmount => carrotUnits / 10f;
    public int RabbitCount { get; private set;  }
    public int MaxBunnies { get; private set; } = 1;
    public float UpgradeCost { get; private set; } = 5;
    public bool CanBeUpgraded => CurrentCarrotAmount >= UpgradeCost;

    private float upgradeCostIncrease = 5; //temporary
    private void Awake()
    {
        notifPrefabPool = new ObjectPool<NotifPopup>(
            createFunc: () => Instantiate(notifPrefab).GetComponent<NotifPopup>(),
            actionOnGet: popUp => popUp.gameObject.SetActive(true),
            actionOnRelease: popUp => popUp.gameObject.SetActive(false),
            actionOnDestroy: popUp => Destroy(popUp.gameObject),
            collectionCheck: true,
            defaultCapacity: 10,
            maxSize: 20
        );
    }

    public void AddRabbit()
    {
        RabbitCount++;
    }

    public void Upgrade()
    {
        ReduceCarrots(UpgradeCost);
        UpgradeCost += upgradeCostIncrease;
        MaxBunnies += 1;
    }

    public bool HasEnoughCarrots(float amount)
    {
        return CurrentCarrotAmount >= amount;
    }

    public void ReduceCarrots(float amount)
    {
        carrotUnits -= Mathf.RoundToInt(amount * 10f);
    }

    public void FarmCarrots(float amount)
    {
        carrotUnits += Mathf.RoundToInt(amount * 10f);
        SpawnPopUp(amount);
    }

    private void SpawnPopUp(float amount)
    {
        Vector3 spawnPoint = transform.position;
        spawnPoint.x += Random.Range(-randomXRangeForPopups, randomXRangeForPopups);

        NotifPopup popup = notifPrefabPool.Get();
        popup.Init(notifPrefabPool, $"+ {amount:F1}".TrimEnd('0').TrimEnd('.'), spawnPoint);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        print("clickled");
        FarmCarrots(clickAmount);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(
            transform.position - Vector3.right * randomXRangeForPopups,
            transform.position + Vector3.right * randomXRangeForPopups
        );
    }
}