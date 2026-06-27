using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CarrotShooter))]
public class ManualCarrotShooter : MonoBehaviour
{
    private CarrotShooter _carrotShooter;
    [Header("Detection")]
    [SerializeField] private float detectionRadius = 8f;
    [SerializeField] private LayerMask rabbitLayer;
    private void Start()
    {
        _carrotShooter = GetComponent<CarrotShooter>();
    }

    private void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Vector2 screenPos = Mouse.current.position.ReadValue();
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(screenPos);
            worldPos.z = 0f;

            FindAndShootClosestRabbit(worldPos);
        }
    }

    public void FindAndShootClosestRabbit(Vector2 clickedPos)
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(clickedPos, detectionRadius, rabbitLayer);
        if (hits.Length == 0)
            return;

        RabbitProletariat target = null;

        foreach (var hit in hits)
        {
            RabbitProletariat rabbit = hit.GetComponent<RabbitProletariat>();
            if (rabbit == null || !rabbit.enabled) continue;

            target = rabbit;
        }

        if (target == null)
            return;

        _carrotShooter.ShootCarrot(target);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.orange;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
