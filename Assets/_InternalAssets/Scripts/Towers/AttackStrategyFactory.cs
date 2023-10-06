using System.Collections.Generic;
using UnityEngine;

public class AttackStrategyFactory
{

    private static Dictionary<(AttackType, AttackType), MergedAttackType> mergedAttackType =
        new Dictionary<(AttackType, AttackType), MergedAttackType>
        {
            {(AttackType.SingleShot, AttackType.MultyShot), MergedAttackType.Single_Multy_Shot},
            {(AttackType.SingleShot, AttackType.AOE), MergedAttackType.Single_AOE_Shot},
            {(AttackType.SingleShot, AttackType.SingleShot), MergedAttackType.Double_Single_Shot},
            
            {(AttackType.MultyShot, AttackType.SingleShot), MergedAttackType.Single_Multy_Shot},
            {(AttackType.MultyShot, AttackType.AOE), MergedAttackType.Multy_Aoe_Shoot},
            {(AttackType.MultyShot, AttackType.MultyShot), MergedAttackType.Double_MultyShot},
            
            {(AttackType.AOE, AttackType.SingleShot), MergedAttackType.Single_AOE_Shot},
            {(AttackType.AOE, AttackType.MultyShot), MergedAttackType.Multy_Aoe_Shoot},
            {(AttackType.AOE, AttackType.AOE), MergedAttackType.Double_AOE_Shoot},
            
            
        };

    
    public static IAttackStrategy CreateStrategy(AttackType attackType, AtackTower tower)
    {
        switch (attackType)
        {
            case AttackType.SingleShot:
                return new SingleShotAttackStrategy(tower);
            case AttackType.MultyShot:
                return new MultyAttackStrategy(tower);
            case AttackType.AOE:
                return new AOEAttackStrategy(tower);
            case AttackType.NoAttack:
                return null;
            default:
                return null;
        }
    }

    public static MergedAttackType MAttackType(AttackType attackType1, AttackType attackType2)
    {
        if (mergedAttackType.TryGetValue((attackType1, attackType2), out var myMergedAttackType))
        {
            return myMergedAttackType;
        }

        return myMergedAttackType;
    }

    public static IAttackStrategy CreateMergedStrategy(AttackType attackType1, AttackType attackType2, MergedTower tower)
    {
        if (mergedAttackType.TryGetValue((attackType1, attackType2), out var myMergedAttackType))
        {
            switch (myMergedAttackType)
            {
                case MergedAttackType.Single_Multy_Shot:
                {
                    Debug.Log("Single_Multy_Shot");
                    return null;
                }
                case MergedAttackType.Single_AOE_Shot:
                {
                    return new Single_AOEAttackStrategy(tower);
                }
                case MergedAttackType.Double_Single_Shot:
                {
                    return new Single_AOEAttackStrategy(tower);
                }
                
                case MergedAttackType.Multy_Aoe_Shoot:
                {
                    Debug.Log("Multy_Aoe_Shoot");
                    return null;
                }
                
                case MergedAttackType.Double_MultyShot:
                {
                    Debug.Log("Double_MultyShot");
                    return null;
                }
                
                case MergedAttackType.Double_AOE_Shoot:
                {
                    Debug.Log("Double_AOE_Shoot");
                    return null;
                }
                default:
                {
                    Debug.Log("No Strategy");
                    return null;
                }
            }
        }

        return null;
    }
}
