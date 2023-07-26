public interface IEnemy
{
    SEnemy Preset { get; }

    float CurHp { get; }
    float MaxHp { get; }

    float CurDefence { get; }
    float MaxDefence { get; }

    float CurSpeed { get; }
    float MaxSpeed { get; }
}
