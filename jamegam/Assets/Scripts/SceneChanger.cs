using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class SceneChanger : MonoBehaviour
{
    public static SceneChanger Instance { get; private set; }

    [SerializeField] private CanvasGroup blackPanel;
    [SerializeField] private float fadeDuration = 0.5f;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    private void Start()
    {
        blackPanel.gameObject.SetActive(true);
        blackPanel.alpha = 1f;
        blackPanel.DOFade(0f, fadeDuration).SetEase(Ease.InQuad);
        blackPanel.gameObject.SetActive(false);
    }

    public void ChangeScene(string sceneName)
    {
        blackPanel.gameObject.SetActive(true);

        blackPanel.DOFade(1f, fadeDuration)
            .SetEase(Ease.OutQuad)
            .OnComplete(() => SceneManager.LoadScene(sceneName));
    }
}