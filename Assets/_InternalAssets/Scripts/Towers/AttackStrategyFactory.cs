public class AttackStrategyFactory
{
    public static IAttackStrategy CreateStrategy(AttackType attackType, AtackTower tower)
    {
        switch (attackType)
        {
            case AttackType.Normal:
                return new SingleShotAttackStrategy(tower);
            case AttackType.MultyShot:
                return null;
            case AttackType.AOE:
                return null;
            default:
                return null;
        }
    }
}
