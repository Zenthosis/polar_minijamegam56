using UnityEngine;
using UnityEngine.Pool;
using DG.Tweening;
using TMPro;

public class NotifPopup : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI label;
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private float floatHeight = 1.5f;
    [SerializeField] private float duration = 1.2f;

    private ObjectPool<NotifPopup> pool;
    private Vector3 startPosition;

    public void Init(ObjectPool<NotifPopup> pool, string message, Vector3 startPos)
    {
        transform.position = startPos;
        startPosition = startPos;

        this.pool = pool;
        label.text = message;

        canvasGroup.alpha = 1f;

        transform.DOMove(startPosition + Vector3.up * floatHeight, duration)
            .SetEase(Ease.OutQuad);

        canvasGroup.DOFade(0f, duration)
            .SetEase(Ease.InQuad)
            .OnComplete(() => pool.Release(this));
    }

    private void OnDisable()
    {
        transform.DOKill();
        canvasGroup.DOKill();
    }
}