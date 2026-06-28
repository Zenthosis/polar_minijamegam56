using UnityEngine;

[System.Serializable]
public struct CarrotDetails
{
    public float speed;
    public float damage;
}

public class CarrotShooter : MonoBehaviour
{
    [Header("Projectile")]
    [SerializeField] private GameObject carrotPrefab;

    [Header("Carrot Stats")]
    [SerializeField] private CarrotDetails carrotDetails = new CarrotDetails { speed = 10f, damage = 20f };

    Farm farm;

    private void Start()
    {
        farm = FindAnyObjectByType<Farm>();
    }

    public void ShootCarrot(RabbitProletariat target)
    {
        if (carrotPrefab == null)
        {
            Debug.LogWarning("[CarrotShooter] No carrot prefab assigned!");
            return;
        }

        if (target == null)
        {
            Debug.LogWarning("[CarrotShooter] No target provided!");
            return;
        }

        // --- basic checks done

        if (farm.HasEnoughCarrots(1))
            farm.ReduceCarrots(1);
        else
            return;

        GameObject carrotGO = Instantiate(carrotPrefab, transform.position + Vector3.up, Quaternion.identity);
        CarrotProjectile carrot = carrotGO.GetComponent<CarrotProjectile>();

        if (carrot != null)
            carrot.TrackTarget(target, carrotDetails);
        else
            Debug.LogWarning("[CarrotShooter] Instantiated carrot prefab is missing a Carrot component!");
    }

    //copy pasted. dirty but no time.
    public void ShootCarrotFree(RabbitProletariat target)
    {
        if (carrotPrefab == null)
        {
            Debug.LogWarning("[CarrotShooter] No carrot prefab assigned!");
            return;
        }

        if (target == null)
        {
            Debug.LogWarning("[CarrotShooter] No target provided!");
            return;
        }

        // --- basic checks done
        GameObject carrotGO = Instantiate(carrotPrefab, transform.position + Vector3.up, Quaternion.identity);
        CarrotProjectile carrot = carrotGO.GetComponent<CarrotProjectile>();

        if (carrot != null)
            carrot.TrackTarget(target, carrotDetails);
        else
            Debug.LogWarning("[CarrotShooter] Instantiated carrot prefab is missing a Carrot component!");
    }

    public float CurrentDamage => carrotDetails.damage;

    public void SetDamage(float damage)
    {
        carrotDetails.damage = damage;
    }

}
