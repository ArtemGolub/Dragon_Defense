using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BuildingStrategy
{
    public static SBuildings Buildings;

    private static Dictionary<MergedAttackType, GameObject> mergedTowerPrefabs =
        new Dictionary<MergedAttackType, GameObject>()
        {
            {MergedAttackType.Single_AOE_Shot, Buildings.Single_AOE_Shot_Prefab},
            {MergedAttackType.Single_Multy_Shot, Buildings.Double_MultyShot_Prefab},
            {MergedAttackType.Double_Single_Shot, Buildings.Double_Single_Shot_Prefab},
            {MergedAttackType.Multy_Aoe_Shoot, Buildings.Multy_Aoe_Shoot_Prefab},
            {MergedAttackType.Double_MultyShot, Buildings.Double_MultyShot_Prefab},
            {MergedAttackType.Double_AOE_Shoot, Buildings.Double_AOE_Shoot_Prefab},
        };

}
