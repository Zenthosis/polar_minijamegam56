using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Wall wall;
    [SerializeField] private GameObject gameOverPanel;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        wall.OnWallBroken += Wall_OnWallBroken;
    }

    private void Wall_OnWallBroken()
    {
        gameOverPanel.SetActive(true);
    }

    public void ResetScene()
    {
        SceneChanger.Instance.ChangeScene("GameScene");
    }
}
