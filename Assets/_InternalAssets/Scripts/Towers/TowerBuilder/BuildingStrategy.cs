using System;
using System.Collections.Generic;
using UnityEngine;

public class BuildingStrategy: MonoBehaviour
{
    public static BuildingStrategy current;
    public SBuildings Buildings;
    
    private Dictionary<MergedAttackType, GameObject> mergedTowerPrefabs = new Dictionary<MergedAttackType, GameObject>();
    
    private void Start()
    {
        mergedTowerPrefabs[MergedAttackType.Single_AOE_Shot] = Buildings.Single_AOE_Shot_Prefab;
        mergedTowerPrefabs[MergedAttackType.Single_Multy_Shot] = Buildings.Single_Multy_Shot_Prefab;
        mergedTowerPrefabs[MergedAttackType.Double_Single_Shot] = Buildings.Double_Single_Shot_Prefab;
        mergedTowerPrefabs[MergedAttackType.Double_MultyShot] = Buildings.Double_MultyShot_Prefab;
        mergedTowerPrefabs[MergedAttackType.Multy_Aoe_Shoot] = Buildings.Multy_Aoe_Shoot_Prefab;
        mergedTowerPrefabs[MergedAttackType.Double_AOE_Shoot] = Buildings.Double_AOE_Shoot_Prefab;
        
        current = this;
    }

    public GameObject CreateObject(MergedAttackType mergedAttackType)
    {
        if (mergedTowerPrefabs.TryGetValue(mergedAttackType, out var objectToCreate))
        {
            return objectToCreate;
        }
        else
        {
            Debug.LogError($"Prefab not found for MergedAttackType: {mergedAttackType}");
            return null;
        }
    }
}
