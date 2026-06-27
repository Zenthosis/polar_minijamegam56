using UnityEngine;

public class CarrotProjectile : MonoBehaviour
{
    private RabbitProletariat target;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float rangeForContactSquared;

    public void TrackTarget(RabbitProletariat target, CarrotDetails details)
    {
        this.target = target;
    }

    private void Update()
    {
        Vector3 direction = target.transform.position - transform.position;
        transform.rotation = Quaternion.Slerp(
            transform.rotation,
            Quaternion.LookRotation(Vector3.forward, direction),
            rotationSpeed * Time.deltaTime
        );

        transform.position += transform.up * 10f * Time.deltaTime;

        if(direction.sqrMagnitude <= rangeForContactSquared)
        {
            target.FeedCarrot(10f);
            Destroy(gameObject);
        }
    }
}
