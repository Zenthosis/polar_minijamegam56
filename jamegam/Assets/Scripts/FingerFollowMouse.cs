using UnityEngine;
using UnityEngine.InputSystem;

public class FingerFollowMouse : MonoBehaviour
{
    //private Transform aimTransform;
        
    //private void Awake()
    //{
    //    aimTransform=transform.Find("Aim");
    //}

    private void Update()
    {
        Vector2 mouseScreenPos= Mouse.current.position.ReadValue();
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(mouseScreenPos);
        Vector3 mouseWorldPosNoZ = new Vector3(mouseWorldPos.x, mouseWorldPos.y, 0f);
        Vector3 aimDirection = (mouseWorldPosNoZ-transform.position).normalized;
        float angle = (Mathf.Atan2(aimDirection.y, aimDirection.x)*Mathf.Rad2Deg)-90f;

        transform.eulerAngles = new Vector3 (0,0,angle);
        //Debug.Log(angle);

    }
}
