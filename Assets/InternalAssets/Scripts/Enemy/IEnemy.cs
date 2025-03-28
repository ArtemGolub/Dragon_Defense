public interface IEnemy
{
    EnemyData Preset { get; }

    float CurHp { get; }
    float MaxHp { get; }
    int DamageValue { get; }

    float CurDefence { get; }
    float MaxDefence { get; }

    float CurSpeed { get; }
    float MaxSpeed { get; }
    
    void SetMoveStrategy(IMoveStrategy strategy);

    void UnitInit();

    void LastPointAchived();
}
