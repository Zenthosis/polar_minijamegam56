using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AYellowpaper.SerializedCollections;

public class Spawner : MonoBehaviour
{
    private float currentBudget;
    private float spawnCooldown;
    private float lowestCost;
    private int currentWave = 1;

    [SerializeField] private SpawnerConfigSO data;
    [SerializeField] private Vector2 spawnRange;
    [SerializeField] private Transform farmLocation;
    private Vector2 halfSpawnRange;


    private void Start()
    {
        halfSpawnRange.x = spawnRange.x / 2;
        halfSpawnRange.y = spawnRange.y / 2;

        currentBudget = data.initialBudget;
        lowestCost = data.rabbitOptionsAndCost.OrderByDescending(x => x.Value).Last().Value;
        Spawn();

        StartCoroutine(SpawnWavesAtIntervals());
    }

    private IEnumerator SpawnWavesAtIntervals()
    {
        while(true)
        {
            Spawn();

            currentWave++; 
            IncreaseBudget();
            SetCooldown();

            yield return new WaitForSeconds(spawnCooldown);
        }
    }

    private void IncreaseBudget()
    {
        currentBudget += data.budgetCurve.Evaluate(currentWave);
    }

    private void SetCooldown()
    {
        spawnCooldown = data.coolDownCurve.Evaluate(currentWave);
    }

    private void Spawn()
    {
        while(currentBudget >= lowestCost)
        {
            GameObject choice = ChooseRabbitToSpawn();
            Vector2 spawnPoint = (Vector2)transform.position + new Vector2(Random.Range(-halfSpawnRange.x, halfSpawnRange.x), Random.Range(-halfSpawnRange.y, halfSpawnRange.y));
            
            GameObject spawnedRabbit = Instantiate(choice, spawnPoint, Quaternion.identity);
            spawnedRabbit.GetComponent<Rabbit>().Init(farmLocation);
        }
    }

    private GameObject ChooseRabbitToSpawn()
    {
        //by default grabs the most expensive one.
        KeyValuePair<GameObject, int> choice = data.rabbitOptionsAndCost.Where(kvp => kvp.Value <= currentBudget)
                                                .OrderByDescending(kvp => kvp.Value)
                                                .FirstOrDefault();

        currentBudget -= choice.Value;
        return choice.Key;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, spawnRange);
    }
}
