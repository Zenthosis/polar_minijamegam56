using UnityEngine;

public class CarrotProjectile : MonoBehaviour
{
    private RabbitProletariat target;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float rangeForContactSquared = 0.2f;

    public void TrackTarget(RabbitProletariat target, CarrotDetails details)
    {
        this.target = target;
    }

    private void Update()
    {
        if (target != null && target.enabled)
        {
            Vector3 direction = target.transform.position - transform.position;
            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                Quaternion.LookRotation(Vector3.forward, direction),
                rotationSpeed * Time.deltaTime
            );

            if (direction.sqrMagnitude <= rangeForContactSquared)
            {
                target.FeedCarrot(10f);
                Destroy(gameObject);
            }
        }
        else
        {
            Destroy(gameObject);
        }

        transform.position += transform.up * 10f * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {   
        Debug.Log($"collision happened");
        RabbitProletariat rabbit = collision.gameObject.GetComponent<RabbitProletariat>();
        if (rabbit != null && rabbit.enabled) 
            rabbit.FeedCarrot(10f);
        
        Destroy(gameObject);
    }
}