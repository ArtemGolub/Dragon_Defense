using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveController : MonoBehaviour
{
    public UnitFabric UnitFabric;
    private SWave Preset;

    public List<SWave> waves;
    private int WaveIndex;
    public float BetweenWavesTime;
    public bool lastWave;
    
    private EnemyType EnemyType;
    private int UnitsAmount;
    private float SpawnRate;

    private int secondToWait = 2;
    
    private void Start()
    {
        InitWave();
        StartWave();
    }

    private void InitWave()
    {
        SetNewWave(waves[WaveIndex]);
        EnemyType = Preset.EnemyType;
        UnitsAmount = Preset.UnitsAmount;
        SpawnRate = Preset.SpawnRate;
        UnitFabric.UpdateFabric(EnemyType);
    }
    private void SetNewWave(SWave preset)
    {
        Preset = preset;
    }
    private void StartWave()
    {
        InvokeRepeating("SpawnNewEnemies", 1, SpawnRate);
    }

    private void SpawnNewEnemies()
    {   
        UnitFabric.SpawnEnemy();
        UnitsAmount--;
        if (UnitsAmount <= 0)
        {
            if (WaveIndex+1 >= waves.Count)
            {
                Debug.Log("Last Wave");
                lastWave = true;
            }
            else
            {
                WaveIndex += 1;
                StartCoroutine(TimerBetweenWaves());
            }
            CancelInvoke();
        }
    }

    private IEnumerator TimerBetweenWaves()
    {
        yield return new WaitForSeconds(BetweenWavesTime);
        InitWave();
        StartWave();
    }

}
