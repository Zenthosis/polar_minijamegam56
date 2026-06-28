using AYellowpaper.SerializedCollections;
using UnityEngine;

[CreateAssetMenu(fileName = "NewSpawnerConfigData", menuName = "SpawnerConfig/SpawnerConfigSO")]

public class SpawnerConfigSO : ScriptableObject
{
    public float initialBudget = 2;
    public SerializedDictionary<GameObject, int> rabbitOptionsAndCost = new();

    public AnimationCurve coolDownCurve;
    public AnimationCurve budgetCurve;
    public AnimationCurve baseChanceCurve;
    public AnimationCurve sickleChanceCurve;
    public AnimationCurve ballChanceCurve;
    public AnimationCurve bomberChanceCurve;
    public AnimationCurve hulkChanceCurve;

    private void OnEnable()
    {
        baseChanceCurve = new AnimationCurve(
            new Keyframe(0f, 0f),
            new Keyframe(1f, 100f),
            new Keyframe(2f, 100f),
            new Keyframe(3f, 100f),
            new Keyframe(4f, 100f),
            new Keyframe(5f, 0f),
            new Keyframe(6f, 80f),
            new Keyframe(7f, 70f),
            new Keyframe(8f, 65f),
            new Keyframe(9f, 0f),
            new Keyframe(10f, 50f),
            new Keyframe(11f, 55f),
            new Keyframe(12f, 55f),
            new Keyframe(13f, 35f),
            new Keyframe(14f, 0f),
            new Keyframe(15f, 60f),
            new Keyframe(16f, 55f),
            new Keyframe(17f, 50f),
            new Keyframe(18f, 0f),
            new Keyframe(19f, 50f),
            new Keyframe(20f, 30f),
            new Keyframe(21f, 10f),
            new Keyframe(22f, 0f),
            new Keyframe(23f, 40f),
            new Keyframe(24f, 40f),
            new Keyframe(25f, 40f)
        ) { preWrapMode = WrapMode.ClampForever, postWrapMode = WrapMode.ClampForever };

        sickleChanceCurve = new AnimationCurve(
            new Keyframe(0f, 0f),
            new Keyframe(1f, 0f),
            new Keyframe(2f, 0f),
            new Keyframe(3f, 0f),
            new Keyframe(4f, 0f),
            new Keyframe(5f, 0f),
            new Keyframe(6f, 0f),
            new Keyframe(7f, 0f),
            new Keyframe(8f, 0f),
            new Keyframe(9f, 0f),
            new Keyframe(10f, 100f),
            new Keyframe(11f, 20f),
            new Keyframe(12f, 30f),
            new Keyframe(13f, 35f),
            new Keyframe(14f, 0f),
            new Keyframe(15f, 30f),
            new Keyframe(16f, 20f),
            new Keyframe(17f, 15f),
            new Keyframe(18f, 30f),
            new Keyframe(19f, 0f),
            new Keyframe(20f, 15f),
            new Keyframe(21f, 15f),
            new Keyframe(22f, 15f),
            new Keyframe(23f, 20f),
            new Keyframe(24f, 20f),
            new Keyframe(25f, 20f)
        ) { preWrapMode = WrapMode.ClampForever, postWrapMode = WrapMode.ClampForever };

        ballChanceCurve = new AnimationCurve(
            new Keyframe(0f, 0f),
            new Keyframe(1f, 0f),
            new Keyframe(2f, 0f),
            new Keyframe(3f, 0f),
            new Keyframe(4f, 0f),
            new Keyframe(5f, 0f),
            new Keyframe(6f, 0f),
            new Keyframe(7f, 0f),
            new Keyframe(8f, 0f),
            new Keyframe(9f, 0f),
            new Keyframe(10f, 0f),
            new Keyframe(11f, 0f),
            new Keyframe(12f, 0f),
            new Keyframe(13f, 0f),
            new Keyframe(14f, 0f),
            new Keyframe(15f, 100f),
            new Keyframe(16f, 20f),
            new Keyframe(17f, 25f),
            new Keyframe(18f, 30f),
            new Keyframe(19f, 35f),
            new Keyframe(20f, 0f),
            new Keyframe(21f, 15f),
            new Keyframe(22f, 0f),
            new Keyframe(23f, 10f),
            new Keyframe(24f, 15f),
            new Keyframe(25f, 15f)
        ) { preWrapMode = WrapMode.ClampForever, postWrapMode = WrapMode.ClampForever };

        bomberChanceCurve = new AnimationCurve(
            new Keyframe(0f, 0f),
            new Keyframe(1f, 0f),
            new Keyframe(2f, 0f),
            new Keyframe(3f, 0f),
            new Keyframe(4f, 0f),
            new Keyframe(5f, 0f),
            new Keyframe(6f, 0f),
            new Keyframe(7f, 0f),
            new Keyframe(8f, 0f),
            new Keyframe(9f, 0f),
            new Keyframe(10f, 0f),
            new Keyframe(11f, 0f),
            new Keyframe(12f, 0f),
            new Keyframe(13f, 0f),
            new Keyframe(14f, 0f),
            new Keyframe(15f, 0f),
            new Keyframe(16f, 0f),
            new Keyframe(17f, 0f),
            new Keyframe(18f, 0f),
            new Keyframe(19f, 0f),
            new Keyframe(20f, 100f),
            new Keyframe(21f, 25f),
            new Keyframe(22f, 30f),
            new Keyframe(23f, 20f),
            new Keyframe(24f, 10f),
            new Keyframe(25f, 15f)
        ) { preWrapMode = WrapMode.ClampForever, postWrapMode = WrapMode.ClampForever };

        hulkChanceCurve = new AnimationCurve(
            new Keyframe(0f, 0f),
            new Keyframe(1f, 0f),
            new Keyframe(2f, 0f),
            new Keyframe(3f, 0f),
            new Keyframe(4f, 0f),
            new Keyframe(5f, 0f),
            new Keyframe(6f, 0f),
            new Keyframe(7f, 0f),
            new Keyframe(8f, 0f),
            new Keyframe(9f, 0f),
            new Keyframe(10f, 0f),
            new Keyframe(11f, 0f),
            new Keyframe(12f, 0f),
            new Keyframe(13f, 0f),
            new Keyframe(14f, 0f),
            new Keyframe(15f, 0f),
            new Keyframe(16f, 0f),
            new Keyframe(17f, 0f),
            new Keyframe(18f, 0f),
            new Keyframe(19f, 0f),
            new Keyframe(20f, 0f),
            new Keyframe(21f, 0f),
            new Keyframe(22f, 0f),
            new Keyframe(23f, 0f),
            new Keyframe(24f, 0f),
            new Keyframe(25f, 100f)
        ) { preWrapMode = WrapMode.ClampForever, postWrapMode = WrapMode.ClampForever };
    }
}
