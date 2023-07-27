using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackStrategyFactory
{
    public static IAttackStrategy CreateStrategy(AttackType attackType)
    {
        switch (attackType)
        {
            case AttackType.Normal:
                return new SingleShotAttackStrategy();
            case AttackType.MultyShot:
                return null;
            case AttackType.AOE:
                return null;
            default:
                return null;
        }
    }
}
