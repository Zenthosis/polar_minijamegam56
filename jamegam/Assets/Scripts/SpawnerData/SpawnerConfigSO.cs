using AYellowpaper.SerializedCollections;
using UnityEngine;

[CreateAssetMenu(fileName = "NewSpawnerConfigData", menuName = "SpawnerConfig/SpawnerConfigSO")]

public class SpawnerConfigSO : ScriptableObject
{
    public float initialBudget = 2;
    public SerializedDictionary<GameObject, int> rabbitOptionsAndCost = new();

    public AnimationCurve coolDownCurve;
    public AnimationCurve budgetCurve;
}
