using UnityEngine;

public class RabbitAnimEffects: MonoBehaviour
{
    private Animator myAnimator;
    private float moveSpeedChange;
    private Rabbit rabbitCS;

    private void Start()
    {
        myAnimator = GetComponentInChildren<Animator>();
        rabbitCS = GetComponent<Rabbit>();
    }

    public void RabbitSpeedChange()
    {
        moveSpeedChange = myAnimator.GetFloat("moveSpeedAnim");
        rabbitCS.moveSpeedBun=moveSpeedChange;
        
    }

    public void destroyRabbit()
    {
        Destroy(gameObject);
    }




}
