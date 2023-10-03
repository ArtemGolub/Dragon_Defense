public class AttackStrategyFactory
{
    public static IAttackStrategy CreateStrategy(AttackType attackType, AtackTower tower)
    {
        switch (attackType)
        {
            case AttackType.Normal:
                return new SingleShotAttackStrategy(tower);
            case AttackType.MultyShot:
                return new MultyAttackStrategy(tower);
            case AttackType.AOE:
                return new AOEAttackStrategy(tower);
            default:
                return null;
        }
    }
}
